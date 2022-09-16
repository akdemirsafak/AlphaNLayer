using Alpha.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alpha.Repository.SeedDatas;

public class SeedCategory : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Phone"
            },
            new Category
            {
                Id = 2,
                Name = "Computer"
            },
            new Category
            {
                Id = 3,
                Name = "Accessory"
            },
            new Category
            {
                Id = 4,
                Name = "Tv"
            }
        );
    }
}