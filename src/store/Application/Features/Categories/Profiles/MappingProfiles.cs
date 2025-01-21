using Application.Features.Categories.Commands.Create;
using Application.Features.Categories.Commands.Delete;
using Application.Features.Categories.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Categories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<Category, CreatedCategoryResponse>();

        CreateMap<DeleteCategoryCommand, Category>();
        CreateMap<Category, DeletedCategoryResponse>();

        CreateMap<Category, GetListCategoryListItemDto>();
    }
}
