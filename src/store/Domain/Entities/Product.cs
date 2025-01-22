using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product : Entity<Guid>
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double UnitPrice { get; set; }

    public virtual Category Category { get; set; } = default!;

    public Product()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Product(int? categoryId, string name, string description, double unitPrice)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }

    public Product(Guid id, int? categoryId, string name, string description, double unitPrice) : base(id)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        UnitPrice = unitPrice;
    }
}
