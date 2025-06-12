using Krovato.Domain.Attributes.Entities;

public class ProductAttribute
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int AttributeDefinitionId { get; set; }
    public string Value { get; set; } = null!;

    public Product Product { get; set; } = null!;
    public AttributeDefinition AttributeDefinition { get; set; } = null!;
}
