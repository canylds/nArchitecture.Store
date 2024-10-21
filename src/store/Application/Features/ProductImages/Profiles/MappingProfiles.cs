using Application.Features.ProductImages.Commands.CreateBulk;
using Application.Features.ProductImages.Commands.Delete;
using Application.Features.ProductImages.Queries.GetById;
using Application.Features.Products.Commands.Delete;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductImage, CbpirProductImageDto>().ReverseMap();

        CreateMap<ProductImage, DeleteProductCommand>().ReverseMap();
        CreateMap<ProductImage, DeletedProductImageResponse>().ReverseMap();

        CreateMap<ProductImage, GetByIdProductImageResponse>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ReverseMap();
    }
}
