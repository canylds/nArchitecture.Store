﻿using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductVariant : Entity<int>
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }

    public virtual Product Product { get; set; } = default!;
    public virtual Color Color { get; set; } = default!;
    public virtual Size Size { get; set; } = default!;

    public ProductVariant()
    {

    }

    public ProductVariant(int productId, int colorId, int sizeId, int unitsInStock)
    {
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }

    public ProductVariant(int id, int productId, int colorId, int sizeId, int unitsInStock) : base(id)
    {
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
    }
}