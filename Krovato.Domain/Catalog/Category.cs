﻿using Krovato.Domain.Common.Interface;
using Krovato.Domain.Products.Entities;

namespace Krovato.Domain.Catalog.Entities;

public class Category : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; } 
    public Guid? ParentId { get; set; }
    public string? Slug { get; set; }

    public Category? Parent { get; set; }
    public ICollection<Category> Children { get; set; } = [];
    public ICollection<Product> Products { get; set; } = [];
}