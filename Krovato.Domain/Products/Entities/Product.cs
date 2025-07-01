using Krovato.Domain.Catalog.Entities;
using Krovato.Domain.Common.Entities;
using Krovato.Domain.Media.Entities;

namespace Krovato.Domain.Products.Entities;
public class Product : AuditableEntity
{
    public Guid CategoryId { get; set; }
    public Guid? BrandId { get; set; }
    public required string Name { get; set; } 
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public int Stock { get; set; }

    public Category Category { get; set; } = null!;
    public Brand? Brand { get; set; }
    public ICollection<ProductAttribute> Attributes { get; set; } = [];
    public ICollection<ProductVariant> Variants { get; set; } = [];
    public ICollection<Image> Images { get; set; } = [];
}