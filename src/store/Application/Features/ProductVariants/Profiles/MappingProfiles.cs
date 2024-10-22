using Application.Features.ProductVariants.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductVariants.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductVariant, GetByIdProductVariantResponse>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.Name))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
            .ReverseMap();
    }
}
