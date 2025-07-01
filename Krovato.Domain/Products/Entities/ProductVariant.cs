using Krovato.Domain.Media.Entities;
using Krovato.Domain.Common.Entities;

namespace Krovato.Domain.Products.Entities;
public class ProductVariant : AuditableEntity
{
    public Guid ProductId { get; set; }
    public required string Sku { get; set; }
    public decimal? Price { get; set; }
    public int Stock { get; set; }

    public Product Product { get; set; } = null!;
    public ICollection<VariantAttribute> Attributes { get; set; } = [];
    public ICollection<Image> Images { get; set; } = [];
}
