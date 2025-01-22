using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }

    public virtual ICollection<Product> Products { get; set; } = default!;

    public Category()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Category(string name, string description, string? imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public Category(int id, string name, string description, string? imageUrl) : base(id)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }
}
