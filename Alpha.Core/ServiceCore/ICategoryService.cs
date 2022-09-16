using Alpha.Core.BaseDtos;
using Alpha.Core.Dtos.Category;
using Alpha.Core.Entities;

namespace Alpha.Core.ServiceCore;

public interface ICategoryService : IGenericService<Category>
{
    Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync();
    Task<ApiResponseDto<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int id);
    Task<ApiResponseDto<AddCategoryDto>> AddAsync(AddCategoryDto categoryDto);
    Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateCategoryDto categoryDto);
}