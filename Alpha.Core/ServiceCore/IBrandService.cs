using Alpha.Core.BaseDtos;
using Alpha.Core.Dtos.Brand;
using Alpha.Core.Entities;

namespace Alpha.Core.ServiceCore;

public interface IBrandService : IGenericService<Brand>
{
    Task<ApiResponseDto<List<BrandDto>>> GetAllAsync();

    Task<ApiResponseDto<BrandDto>> GetByIdAsync(int id);

    //Task<ApiResponseDto<List<AddBrandDto>>> AddRangeAsync(List<AddBrandDto> entities);
    Task<ApiResponseDto<AddBrandDto>> AddAsync(AddBrandDto entity);
    Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateBrandDto entity);
}