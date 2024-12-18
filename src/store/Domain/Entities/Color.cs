﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Color : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<ProductVariant> ProductVariants { get; set; } = default!;

    public Color()
    {
        Name = string.Empty;
    }

    public Color(string name)
    {
        Name = name;
    }

    public Color(int id, string name) : base(id)
    {
        Name = name;
    }
}
