namespace Alpha.Core.Dtos.Products;

public class AddProductDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int BrandId { get; set; }
    public int CategoryId { get; set; }
}