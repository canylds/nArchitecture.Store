using Application.Features.Sizes.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Sizes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSizeCommand, Size>();
        CreateMap<Size, CreatedSizeResponse>();
    }
}
