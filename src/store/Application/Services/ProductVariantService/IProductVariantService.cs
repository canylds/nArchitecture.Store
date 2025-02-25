using Domain.Entities;

namespace Application.Services.ProductVariantService;

public interface IProductVariantService
{
    Task<ICollection<ProductVariant>> AddRangeAsync(ICollection<ProductVariant> productVariants);
}
