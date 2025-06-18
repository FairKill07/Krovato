using Krovato.Domain.Common.Interface;
using Krovato.Domain.Products.Entities;

namespace Krovato.Domain.Media.Entities
{
    public class Image : IEntity
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? VariantId { get; set; }

        public string Url { get; set; } = null!;
        public string? AltText { get; set; }

        public Product? Product { get; set; }
        public ProductVariant? Variant { get; set; }
    }

}
