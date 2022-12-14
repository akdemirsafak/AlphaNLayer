namespace Alpha.Core.Dtos.Category;

public class CategoriesProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int BrandId { get; set; }
}