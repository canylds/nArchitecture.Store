using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductImage : Entity<int>
{
    public int ProductId { get; set; }
    public string Url { get; set; }

    public virtual Product Product { get; set; } = default!;

    public ProductImage()
    {
        Url = string.Empty;
    }

    public ProductImage(int productId, string url)
    {
        ProductId = productId;
        Url = url;
    }
}
