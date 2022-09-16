using Alpha.Core.BaseDtos;
using Alpha.Core.Dtos.Brand;
using Alpha.Core.Entities;
using Alpha.Core.RepositoryCore;
using Alpha.Core.ServiceCore;
using Alpha.Core.UnitOfWorkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Service.Services;

public class BrandService : GenericService<Brand>, IBrandService
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public BrandService(IGenericRepository<Brand> genericRepository, IUnitOfWork unitOfWork,
        IBrandRepository brandRepository, IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponseDto<List<BrandDto>>> GetAllAsync()
    {
        var data = await _brandRepository.GetAll().ToListAsync();
        var result = _mapper.Map<List<BrandDto>>(data);
        return ApiResponseDto<List<BrandDto>>.Success(200, result);
    }


    public async Task<ApiResponseDto<BrandDto>> GetByIdAsync(int id)
    {
        var data = await _brandRepository.FindAsync(id);
        return ApiResponseDto<BrandDto>.Success(200, _mapper.Map<BrandDto>(data));
    }

    public async Task<ApiResponseDto<AddBrandDto>> AddAsync(AddBrandDto entity)
    {
        var brand = _mapper.Map<Brand>(entity);
        await _brandRepository.AddAsync(brand);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<AddBrandDto>.Success(201, entity);
    }

    public async Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateBrandDto entity)
    {
        var data = _mapper.Map<Brand>(entity);
        _brandRepository.Update(data);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(204);
    }

    public async Task<ApiResponseDto<List<AddBrandDto>>> AddRangeAsync(List<AddBrandDto> entities)
    {
        var brands = _mapper.Map<List<Brand>>(entities);
        await _brandRepository.AddRangeAsync(brands);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<List<AddBrandDto>>.Success(201, entities);
    }
}