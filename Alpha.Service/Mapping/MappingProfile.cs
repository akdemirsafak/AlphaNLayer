using Alpha.Core.Dtos.Brand;
using Alpha.Core.Dtos.Category;
using Alpha.Core.Dtos.Products;
using Alpha.Core.Entities;
using AutoMapper;

namespace Alpha.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductWithCategoryAndBrandDto>()
            .ForMember(dest => dest.BrandName,
                src => src.MapFrom(opt => opt.Brand.Name)
            )
            .ForMember(dest => dest.CategoryName,
                src => src.MapFrom(opt => opt.Category.Name)
            );

        CreateMap<Product, CategoriesProductDto>();
        CreateMap<AddProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();


        CreateMap<Category, CategoryWithProductsDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<UpdateCategoryDto, Category>();
        CreateMap<AddCategoryDto, Category>();

        CreateMap<Brand, BrandDto>();
        CreateMap<AddBrandDto, Brand>();
        CreateMap<UpdateBrandDto, Brand>();
    }
}