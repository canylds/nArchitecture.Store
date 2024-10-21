using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Size : Entity<int>
{
    public string Name { get; set; }

    public Size()
    {
        Name = string.Empty;
    }

    public Size(string name)
    {
        Name = name;
    }

    public Size(int id, string name) : base(id)
    {
        Name = name;
    }
}
