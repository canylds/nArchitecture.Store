using Application.Features.ProductImages.Commands.Delete;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductImage, DeleteProductImageCommand>().ReverseMap();
        CreateMap<ProductImage, DeletedProductImageResponse>().ReverseMap();
    }
}
