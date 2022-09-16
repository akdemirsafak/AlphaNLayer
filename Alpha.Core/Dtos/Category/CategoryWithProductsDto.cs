namespace Alpha.Core.Dtos.Category;

public class CategoryWithProductsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CategoriesProductDto> Products { get; set; }
}