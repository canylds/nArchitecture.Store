﻿using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductService;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductManager(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate,
        Func<IQueryable<Product>,
            IIncludableQueryable<Product, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        Product? product = await _productRepository.GetAsync(predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken);

        return product;
    }
}