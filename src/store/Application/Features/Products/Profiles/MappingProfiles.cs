using Application.Features.Products.Queries.GetPagedList;
using AutoMapper;
using core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Products.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductVariant, GplplidProductVariantDto>()
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name));
        CreateMap<ProductImage, GplplidProductImageDto>();
        CreateMap<Product, GetPagedListProductListItemDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.ProductVariants))
            .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));
        CreateMap<IPaginate<Product>, GetPagedListResponse<GetPagedListProductListItemDto>>();
    }
}
