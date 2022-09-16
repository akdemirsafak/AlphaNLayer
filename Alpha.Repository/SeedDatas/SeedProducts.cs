using Alpha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Repository.SeedDatas;

public class SeedProducts : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Iphone 14 Pro",
                Description = "Really Expensive Phone",
                Price = 40000,
                Stock = 1,
                CreatedAt = DateTime.Now,
                BrandId = 1,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Macbook",
                Description = "Macos Monterey",
                Price = 50000,
                Stock = 5,
                CreatedAt = DateTime.Now,
                BrandId = 1,
                CategoryId = 2
            },
            new Product
            {
                Id = 3,
                Name = "Mechanical Keyboard",
                Description = "Description",
                Price = 250,
                Stock = 100,
                CreatedAt = DateTime.Now,
                BrandId = 5,
                CategoryId = 3
            },
            new Product
            {
                Id = 4,
                Name = "Bravia TV",
                Description = "Real colors with OLED technology",
                Price = 100000,
                Stock = 200,
                CreatedAt = DateTime.Now,
                BrandId = 6,
                CategoryId = 4
            }
        );
    }
}