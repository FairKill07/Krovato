using Krovato.Domain.Common.Interface;
using Krovato.Domain.Products.Entities;

namespace Krovato.Domain.Catalog.Entities;

public class Brand : IEntity
{
    public Guid Id { get; set; }
    public required string Name { get; set; } 
    public string? Country { get; set; }
    public string? Description { get; set; }

    public ICollection<Product> Products { get; set; } = [];
}