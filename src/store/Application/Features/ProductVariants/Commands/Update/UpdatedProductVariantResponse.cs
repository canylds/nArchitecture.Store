﻿using Core.Application.Responses;

namespace Application.Features.ProductVariants.Commands.Update;

public class UpdatedProductVariantResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int SizeId { get; set; }
    public int UnitsInStock { get; set; }
    public string ProductName { get; set; }
    public string ColorName { get; set; }
    public string SizeName { get; set; }

    public UpdatedProductVariantResponse()
    {
        ProductName = string.Empty;
        ColorName = string.Empty;
        SizeName = string.Empty;
    }

    public UpdatedProductVariantResponse(int id,
        int productId,
        int colorId,
        int sizeId,
        int unitsInStock,
        string productName,
        string colorName,
        string sizeName)
    {
        Id = id;
        ProductId = productId;
        ColorId = colorId;
        SizeId = sizeId;
        UnitsInStock = unitsInStock;
        ProductName = productName;
        ColorName = colorName;
        SizeName = sizeName;
    }
}