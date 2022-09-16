using System.Reflection;
using Alpha.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Repository.Context;

public class AlphaDBContext : DbContext
{
    public AlphaDBContext(DbContextOptions<AlphaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; } = null!;
    public virtual DbSet<Category> Categories { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }


    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
            if (item.Entity is BaseEntity entityReference)
                switch (item.State)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreatedAt = DateTime.Now;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        entityReference.UpdatedAt = DateTime.Now;
                        Entry(entityReference).Property(x => x.CreatedAt).IsModified = false;
                        break;
                    }
                }

        return base.SaveChanges();
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries())
            if (item.Entity is BaseEntity entityReference)
                switch (item.State)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreatedAt = DateTime.Now;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        entityReference.UpdatedAt = DateTime.Now;
                        Entry(entityReference).Property(x => x.CreatedAt).IsModified = false;
                        break;
                    }
                }

        return base.SaveChangesAsync(cancellationToken);
    }
}