using Krovato.Domain.Attributes.Entities;
using Krovato.Domain.Products.Entities;

public class ProductAttribute
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid AttributeDefinitionId { get; set; }
    public string Value { get; set; } = null!;

    public Product Product { get; set; } = null!;
    public AttributeDefinition AttributeDefinition { get; set; } = null!;
}
