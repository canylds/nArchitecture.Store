using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Size : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = default!;

    public Size()
    {
        Name = string.Empty;
    }

    public Size(string name)
    {
        Name = name;
    }
}