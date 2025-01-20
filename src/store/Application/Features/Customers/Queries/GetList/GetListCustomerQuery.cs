using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.Customers.Constants.CustomersOperationClaims;

namespace Application.Features.Customers.Queries.GetList;

public class GetListCustomerQuery : IRequest<IList<GetListCustomerListItemDto>>, ISecuredRequest
{
    public string[] Roles => [Admin, Read];

    public class GetListCustomerQueryHandler
        : IRequestHandler<GetListCustomerQuery, IList<GetListCustomerListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<IList<GetListCustomerListItemDto>> Handle(GetListCustomerQuery request,
            CancellationToken cancellationToken)
        {
            IList<Customer> customers = await _customerRepository.GetListAsync(include: query => query.Include(c => c.User),
                enableTracking: false,
                cancellationToken: cancellationToken);

            IList<GetListCustomerListItemDto> response = _mapper.Map<IList<GetListCustomerListItemDto>>(customers);

            return response;
        }
    }
}