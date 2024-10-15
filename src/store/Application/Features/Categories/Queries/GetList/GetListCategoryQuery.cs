using Application.Services.Repositories;
using AutoMapper;
using core.Application.Responses;
using Core.Application.Pipelines.Logging;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<GetListResponse<GetListCategoryListItemDto>>, ILoggableRequest
{
    public PageRequest PageRequest { get; set; }

    public GetListCategoryQuery()
    {
        PageRequest = new PageRequest
        {
            PageIndex = 0,
            PageSize = 10
        };
    }

    public GetListCategoryQuery(PageRequest pageRequest)
    {
        PageRequest = pageRequest;
    }

    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, GetListResponse<GetListCategoryListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetListCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetListResponse<GetListCategoryListItemDto>> Handle(GetListCategoryQuery request,
        CancellationToken cancellationToken)
        {
            IPaginate<Category> categories =
            await _categoryRepository.GetListAsync(orderBy: query => query.OrderBy(c => c.Name),
            index: request.PageRequest.PageIndex,
            size: request.PageRequest.PageSize,
            enableTracking: false,
            cancellationToken: cancellationToken);

            GetListResponse<GetListCategoryListItemDto> response =
            _mapper.Map<GetListResponse<GetListCategoryListItemDto>>(categories);

            return response;
        }
    }
}