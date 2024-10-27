using Application.Features.ProductVariants.Commands.Create;
using Application.Features.ProductVariants.Commands.CreateBulk;
using Application.Features.ProductVariants.Commands.Update;
using Application.Features.ProductVariants.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductVariants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductVariant, CreateProductVariantCommand>().ReverseMap();
        CreateMap<ProductVariant, CreatedProductVariantResponse>().ReverseMap();

        CreateMap<ProductVariant, CbpvcProductVariantDto>().ReverseMap();
        CreateMap<ProductVariant, CbpvrProductVariantDto>().ReverseMap();

        CreateMap<ProductVariant, UpdateProductVariantCommand>().ReverseMap();
        CreateMap<ProductVariant, UpdatedProductVariantResponse>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
            .ReverseMap();

        CreateMap<ProductVariant, GetByIdProductVariantResponse>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
            .ReverseMap();
    }
}
