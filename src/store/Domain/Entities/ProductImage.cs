using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductImage : Entity<int>
{
    public Guid ProductId { get; set; }
    public string Url { get; set; }

    public virtual Product Product { get; set; } = default!;

    public ProductImage()
    {
        Url = string.Empty;
    }

    public ProductImage(Guid productId, string url)
    {
        ProductId = productId;
        Url = url;
    }

    public ProductImage(int id, Guid productId, string url) : base(id)
    {
        ProductId = productId;
        Url = url;
    }
}
