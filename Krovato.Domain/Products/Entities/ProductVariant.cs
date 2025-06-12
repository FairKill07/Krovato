using Krovato.Domain.Media.Entities;
using Krovato.Domain.Common.Entities;

namespace Krovato.Domain.Products.Entities;
public class ProductVariant : AuditableEntity
{
    public int ProductId { get; set; }
    public string Sku { get; set; } = null!;
    public decimal? Price { get; set; }
    public int Stock { get; set; }

    public Product Product { get; set; } = null!;
    public ICollection<VariantAttribute> Attributes { get; set; } = new List<VariantAttribute>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
}
