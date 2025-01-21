using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Sizes.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Colors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateColorCommand, Color>();
        CreateMap<Color, CreatedColorResponse>();

        CreateMap<DeleteColorCommand, Color>();
        CreateMap<Color, DeletedColorResponse>();
    }
}
