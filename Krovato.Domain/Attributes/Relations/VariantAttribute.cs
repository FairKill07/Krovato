using Krovato.Domain.Attributes.Entities;
using Krovato.Domain.Products.Entities;

public class VariantAttribute
{
    public Guid Id { get; set; }
    public Guid VariantId { get; set; }
    public Guid AttributeDefinitionId { get; set; }
    public required string Value { get; set; }

    public required ProductVariant Variant { get; set; }
    public required AttributeDefinition AttributeDefinition { get; set; } 
}
