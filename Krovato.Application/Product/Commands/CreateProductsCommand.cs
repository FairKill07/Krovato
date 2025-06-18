using MediatR;

namespace Krovato.Application.Products.Commands
{
    public class CreateProductsCommand : IRequest<Guid>
    {
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }

        // Additional properties for product attributes, variants, and images can be added here
        // For example:
        // public List<ProductAttributeDto> Attributes { get; set; } = new List<ProductAttributeDto>();
        // public List<ProductVariantDto> Variants { get; set; } = new List<ProductVariantDto>();
        // public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
