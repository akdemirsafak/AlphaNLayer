using System.Reflection;
using System.Threading.RateLimiting;
using Alpha.API.DependencyResolvers;
using Alpha.API.Filters;
using Alpha.API.Middlewares;
using Alpha.Repository.Context;
using Alpha.Service.Mapping;
using Alpha.Service.Validations.Product;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
    {
        opt.Filters.Add(new ValidateFilterAttribute()); //Validate Filter Activated
    })
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<AddProductDtoValidator>());
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
}); //FluentValidation kendi modelini döner fakat biz customresponse dto döndüğümüz için bu default ayarı kapattık.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AlphaDBContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AlphaDBContext))!.GetName()
            .Name);
    });
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

//Import IoContainer
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new IoContainer()));


var app = builder.Build();


//? TokenLimiterOptions

app.UseRateLimiter(new RateLimiterOptions
{
    GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        return RateLimitPartition.CreateTokenBucketLimiter<string>("TokenBucketLimit",
            _ => new TokenBucketRateLimiterOptions(10, QueueProcessingOrder.NewestFirst, 0, TimeSpan.FromSeconds(10),
                10));
    }),
    RejectionStatusCode = 429
});
// ? TokenLimiterOptions


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCustomException();
app.MapControllers();

app.Run();