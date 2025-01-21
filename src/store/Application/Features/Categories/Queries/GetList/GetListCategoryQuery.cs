using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Categories.Queries.GetList;

public class GetListCategoryQuery : IRequest<IList<GetListCategoryListItemDto>>
{
    public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, IList<GetListCategoryListItemDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetListCategoryListItemDto>> Handle(GetListCategoryQuery request, 
            CancellationToken cancellationToken)
        {
            IList<Category> categories = await _categoryRepository.GetListAsync(enableTracking: false,
                cancellationToken: cancellationToken);

            IList<GetListCategoryListItemDto> response = _mapper.Map<IList<GetListCategoryListItemDto>>(categories);

            return response;
        }
    }
}