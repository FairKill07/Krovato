namespace Krovato.Domain.Attributes.Entities
{
    public class AttributeDefinition
    {
        public Guid Id { get; set; }
        public required string Name { get; set; } 
        public AttributeDataType DataType { get; set; } = AttributeDataType.Text;

        public required ICollection<AttributeOption> Options { get; set; }
    }

}
