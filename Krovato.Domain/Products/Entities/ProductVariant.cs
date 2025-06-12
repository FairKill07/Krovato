using Krovato.Domain.Media.Entities;
namespace Krovato.Domain.Products.Entities;
public class ProductVariant
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Sku { get; set; } = null!;
    public decimal? Price { get; set; }
    public int Stock { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Product Product { get; set; } = null!;
    public ICollection<VariantAttribute> Attributes { get; set; } = new List<VariantAttribute>();
    public ICollection<Image> Images { get; set; } = new List<Image>();
}
