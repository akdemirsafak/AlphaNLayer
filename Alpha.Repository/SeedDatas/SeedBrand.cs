using Alpha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Repository.SeedDatas;

public class SeedBrand : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasData(
            new Brand
            {
                Id = 1,
                Name = "Apple",
                CreatedAt = DateTime.Now
            },
            new Brand
            {
                Id = 2,
                Name = "Samsung",
                CreatedAt = DateTime.Now.AddMonths(-1)
            },
            new Brand
            {
                Id = 3,
                Name = "Xiaomi",
                CreatedAt = DateTime.Now.AddDays(-1)
            },
            new Brand
            {
                Id = 4,
                Name = "Huawei",
                CreatedAt = DateTime.Now.AddDays(-200)
            },
            new Brand
            {
                Id = 5,
                Name = "Asus",
                Description = "Computer and Accessory Professionals",
                CreatedAt = DateTime.Now.AddDays(-100)
            },
            new Brand
            {
                Id = 6,
                Name = "Sony",
                CreatedAt = DateTime.Now.AddMonths(-5)
            }
        );
    }
}