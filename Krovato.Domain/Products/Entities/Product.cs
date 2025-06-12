namespace Krovato.Domain.Products.Entities;

using Krovato.Domain.Catalog.Entities;
using Krovato.Domain.Common.Entities;
using Krovato.Domain.Media.Entities;

public class Product : AuditableEntity
{
    public int CategoryId { get; set; }
    public int? BrandId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal BasePrice { get; set; }
    public int Stock { get; set; }

    public Category Category { get; set; } = null!;
    public Brand? Brand { get; set; }
    public ICollection<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
}