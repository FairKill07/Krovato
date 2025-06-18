using Krovato.Domain.Attributes.Entities;
using Krovato.Domain.Products.Entities;

public class VariantAttribute
{
    public Guid Id { get; set; }
    public Guid VariantId { get; set; }
    public Guid AttributeDefinitionId { get; set; }
    public string Value { get; set; } = null!;

    public ProductVariant Variant { get; set; } = null!;
    public AttributeDefinition AttributeDefinition { get; set; } = null!;
}
