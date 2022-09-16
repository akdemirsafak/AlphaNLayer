using System.Reflection;
using Alpha.Core.RepositoryCore;
using Alpha.Core.ServiceCore;
using Alpha.Core.UnitOfWorkCore;
using Alpha.Repository.Context;
using Alpha.Repository.Repositories;
using Alpha.Repository.UnitOfWorks;
using Alpha.Service.Mapping;
using Alpha.Service.Services;
using Autofac;
using Module = Autofac.Module;

namespace Alpha.API.DependencyResolvers;

public class IoContainer : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

        //Tip güvenli
        var apiAssembly = Assembly.GetExecutingAssembly();
        var repoAssembly = Assembly.GetAssembly(typeof(AlphaDBContext));
        var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));


        //Tüm service ve respositoryleri tek tek belirtmek yerine service veya repository ile bitenleri inject etmesini istedik.
        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
        builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}