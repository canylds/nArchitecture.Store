namespace Application.Services.ProductService;

public interface IProductService
{
    Task UnassignCategoryFromProductsAsync(int categoryId);
}
