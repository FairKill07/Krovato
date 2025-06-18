namespace Krovato.Domain.Attributes.Entities
{
    public class AttributeDefinition
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public AttributeDataType DataType { get; set; } = AttributeDataType.Text;
    }

}
