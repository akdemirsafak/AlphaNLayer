namespace Alpha.Core.Dtos.Brand;

public class BrandWithProductsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<BrandsProductDto> Products { get; set; }
}