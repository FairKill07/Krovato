using Krovato.Domain.Attributes.Entities;
using Krovato.Domain.Products.Entities;

public class ProductAttribute
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid AttributeDefinitionId { get; set; }
    public required string Value { get; set; } 

    public required Product Product { get; set; } 
    public required AttributeDefinition AttributeDefinition { get; set; } 
}
