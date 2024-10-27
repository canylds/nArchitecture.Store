using Application.Features.ProductVariants.Constants;
using Application.Features.ProductVariants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Features.ProductVariants.Constants.ProductVariantsOperationClaims;

namespace Application.Features.ProductVariants.Commands.Update;

public class UpdateProductVariantCommand : IRequest<UpdatedProductVariantResponse>, ISecuredRequest,
    ILoggableRequest
{
    public int Id { get; set; }
    public int UnitsInStock { get; set; }

    public string[] Roles => [Admin, Write, ProductVariantsOperationClaims.Update];

    public UpdateProductVariantCommand()
    {

    }

    public UpdateProductVariantCommand(int id, int unitsInStock)
    {
        Id = id;
        UnitsInStock = unitsInStock;
    }

    public class UpdateProductVariantCommandHandler
        : IRequestHandler<UpdateProductVariantCommand, UpdatedProductVariantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;

        public UpdateProductVariantCommandHandler(IMapper mapper,
            IProductVariantRepository productVariantRepository,
            ProductVariantBusinessRules productVariantBusinessRules)
        {
            _mapper = mapper;
            _productVariantRepository = productVariantRepository;
            _productVariantBusinessRules = productVariantBusinessRules;
        }

        public async Task<UpdatedProductVariantResponse> Handle(UpdateProductVariantCommand request,
            CancellationToken cancellationToken)
        {
            ProductVariant? productVariant = await _productVariantRepository.GetAsync(predicate: pv => pv.Id == request.Id,
                include: query => query.Include(pv => pv.Product).Include(pv => pv.Color).Include(pv => pv.Size),
                cancellationToken: cancellationToken);

            await _productVariantBusinessRules.ProductVariantShouldExistWhenSelected(productVariant);

            _mapper.Map(request, productVariant);

            await _productVariantRepository.UpdateAsync(productVariant!, cancellationToken);

            UpdatedProductVariantResponse response = _mapper.Map<UpdatedProductVariantResponse>(productVariant);

            return response;
        }
    }
}
