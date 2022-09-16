using Alpha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Repository.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(e => e.Name).HasMaxLength(64);
        builder.Property(e => e.Description).HasMaxLength(1024);
        builder.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        builder.Property(e => e.Stock).IsRequired();
    }
}