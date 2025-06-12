using Krovato.Domain.Products.Entities;

namespace Krovato.Domain.Media.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? VariantId { get; set; }

        public string Url { get; set; } = null!;
        public string? AltText { get; set; }

        public Product? Product { get; set; }
        public ProductVariant? Variant { get; set; }
    }

}
