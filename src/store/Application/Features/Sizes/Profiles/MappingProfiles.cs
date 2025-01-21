using Application.Features.Sizes.Commands.Create;
using Application.Features.Sizes.Commands.Delete;
using Application.Features.Sizes.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Sizes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSizeCommand, Size>();
        CreateMap<Size, CreatedSizeResponse>();

        CreateMap<DeleteSizeCommand, Size>();
        CreateMap<Size, DeletedSizeResponse>();

        CreateMap<Size, GetListSizeListItemDto>();
    }
}
