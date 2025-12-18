using AutoMapper;
using MicroserviceECommerce.Catalog.WebAPI.Dtos.CategoryDtos;
using MicroserviceECommerce.Catalog.WebAPI.Dtos.ProductDetailDtos;
using MicroserviceECommerce.Catalog.WebAPI.Dtos.ProductDtos;
using MicroserviceECommerce.Catalog.WebAPI.Dtos.ProductImageDtos;
using MicroserviceECommerce.Catalog.WebAPI.Entities;

namespace MicroserviceECommerce.Catalog.WebAPI.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, GetByIdCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, GetByIdProductDto>().ReverseMap();
        CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, GetByIdProductDetailDto>().ReverseMap();
    }
}