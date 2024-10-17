using Application.Features.ProductImages.Commands.CreateBulk;
using Application.Features.ProductImages.Commands.Delete;
using Application.Features.Products.Commands.Delete;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.ProductImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProductImage, CbpirProductImageDto>();

        CreateMap<ProductImage, DeleteProductCommand>();
        CreateMap<ProductImage, DeletedProductImageResponse>();
    }
}
