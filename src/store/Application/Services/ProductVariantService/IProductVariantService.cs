using Domain.Entities;

namespace Application.Services.ProductVariantService;

public interface IProductVariantService
{
    Task<ICollection<ProductVariant>> AddRangeAsync(ICollection<ProductVariant> productVariants);
    Task<ICollection<ProductVariant>> UpdateRangeAsync(ICollection<ProductVariant> productVariants);
    Task<ICollection<ProductVariant>> DeleteRangeAsync(ICollection<ProductVariant> productVariants,
        bool permanent = false);
}
