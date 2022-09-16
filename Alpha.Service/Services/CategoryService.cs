using Alpha.Core.BaseDtos;
using Alpha.Core.Dtos.Category;
using Alpha.Core.Entities;
using Alpha.Core.RepositoryCore;
using Alpha.Core.ServiceCore;
using Alpha.Core.UnitOfWorkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Service.Services;

public class CategoryService : GenericService<Category>, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IGenericRepository<Category> genericRepository, IUnitOfWork unitOfWork,
        ICategoryRepository categoryRepository, IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponseDto<List<CategoryDto>>> GetAllAsync()
    {
        var entity = await _categoryRepository.GetAll().ToListAsync();
        var dto = _mapper.Map<List<CategoryDto>>(entity);
        return ApiResponseDto<List<CategoryDto>>.Success(200, dto);
    }

    public async Task<ApiResponseDto<CategoryWithProductsDto>> GetCategoryWithProductsAsync(int id)
    {
        var result = await _categoryRepository.GetCategoryWithProducts(id);
        var dto = _mapper.Map<CategoryWithProductsDto>(result);
        return ApiResponseDto<CategoryWithProductsDto>.Success(200, dto);
    }

    public async Task<ApiResponseDto<AddCategoryDto>> AddAsync(AddCategoryDto categoryDto)
    {
        var entity = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<AddCategoryDto>.Success(201, categoryDto);
    }

    public async Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateCategoryDto categoryDto)
    {
        var entity = _mapper.Map<Category>(categoryDto);
        _categoryRepository.Update(entity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(204);
    }
}