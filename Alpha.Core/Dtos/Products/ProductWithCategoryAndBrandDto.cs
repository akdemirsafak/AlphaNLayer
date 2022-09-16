namespace Alpha.Core.Dtos.Products;

public class ProductWithCategoryAndBrandDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
}