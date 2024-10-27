using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using AutoMapper;
using core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CpcProductVariantDto, ProductVariant>();
        CreateMap<CreateProductCommand, Product>().ForMember(dest => dest.ProductVariants, opt => opt.Ignore());
        CreateMap<ProductVariant, CprProductVariantDto>();
        CreateMap<Product, CreatedProductResponse>();

        CreateMap<UpdateProductCommand, Product>().ForMember(dest => dest.ProductVariants, opt => opt.Ignore());
        CreateMap<ProductVariant, UprProductVariantDto>();
        CreateMap<Product, UpdatedProductResponse>();

        CreateMap<DeleteProductCommand, Product>();
        CreateMap<Product, DeletedProductResponse>();

        CreateMap<ProductImage, GbiprProductImageDto>();
        CreateMap<ProductVariant, GbiprProductVariantDto>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
            .ReverseMap();
        CreateMap<Product, GetByIdProductResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));

        CreateMap<ProductImage, GlplidProductImageDto>();
        CreateMap<ProductVariant, GlplidProductVariantDto>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name));
        CreateMap<Product, GetListProductListItemDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));
        CreateMap<IPaginate<Product>, GetListResponse<GetListProductListItemDto>>();
    }
}
