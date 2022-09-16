using Alpha.Core.BaseDtos;
using Alpha.Core.Dtos.Products;
using Alpha.Core.Entities;
using Alpha.Core.RepositoryCore;
using Alpha.Core.ServiceCore;
using Alpha.Core.UnitOfWorkCore;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Service.Services;

public class ProductService : GenericService<Product>, IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IGenericRepository<Product> genericRepository, IUnitOfWork unitOfWork,
        IProductRepository productRepository, IMapper mapper) : base(genericRepository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponseDto<List<ProductDto>>> GetAllAsync()
    {
        var products = await _productRepository.GetAll().ToListAsync();
        var productsDto = _mapper.Map<List<ProductDto>>(products);
        return ApiResponseDto<List<ProductDto>>.Success(200, productsDto);
    }


    public async Task<ApiResponseDto<ProductDto>> GetByIdAsync(int id)
    {
        var product = await _productRepository.FindAsync(id);
        var productDto = _mapper.Map<ProductDto>(product);
        return ApiResponseDto<ProductDto>.Success(200, productDto);
    }


    public async Task<ApiResponseDto<NoContentDto>> AddAsync(AddProductDto productDto)
    {
        var entity = _mapper.Map<Product>(productDto);
        await _productRepository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(201);
    }

    public async Task<ApiResponseDto<List<ProductWithCategoryAndBrandDto>>> GetProductsWithCategoryAndBrand()
    {
        var products = await _productRepository.GetProductsWithCategoryAndBrand();
        var dto = _mapper.Map<List<ProductWithCategoryAndBrandDto>>(products);
        return ApiResponseDto<List<ProductWithCategoryAndBrandDto>>.Success(200, dto);
    }

    public async Task<ApiResponseDto<NoContentDto>> UpdateAsync(UpdateProductDto updateProductDto)
    {
        //var product = await _productRepository.FindAsync(updateProductDto.Id);
        var entity = _mapper.Map<Product>(updateProductDto);
        _productRepository.Update(entity);
        await _unitOfWork.CommitAsync();
        return ApiResponseDto<NoContentDto>.Success(204);
    }
}