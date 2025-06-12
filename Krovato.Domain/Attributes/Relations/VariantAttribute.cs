using Krovato.Domain.Attributes.Entities;

public class VariantAttribute
{
    public int Id { get; set; }
    public int VariantId { get; set; }
    public int AttributeDefinitionId { get; set; }
    public string Value { get; set; } = null!;

    public ProductVariant Variant { get; set; } = null!;
    public AttributeDefinition AttributeDefinition { get; set; } = null!;
}
