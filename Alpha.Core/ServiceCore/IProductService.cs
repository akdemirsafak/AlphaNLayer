using Alpha.Core.BaseDtos;
using Alpha.Core.Dtos.Products;
using Alpha.Core.Entities;

namespace Alpha.Core.ServiceCore;

public interface IProductService : IGenericService<Product>
{
    Task<ApiResponseDto<List<ProductDto>>> GetAllAsync();

    Task<ApiResponseDto<ProductDto>> GetByIdAsync(int id);

    Task<ApiResponseDto<List<ProductWithCategoryAndBrandDto>>> GetProductsWithCategoryAndBrand();

    //Task<ApiResponseDto<List<NoContentDto>>> GetProductsWithCategory();
    Task<ApiResponseDto<NoContentDto>> AddAsync(AddProductDto productDto);
    Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateProductDto updateProductDto);
}