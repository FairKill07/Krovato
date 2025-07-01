using MediatR;

namespace Krovato.Application.Attribute.Commands
{
    class CreateAttributeDefinitionCommand : IRequest<Guid>
    {
        public required string Name { get; set; }

        public AttributeDataType DataType { get; set; } = AttributeDataType.Text;
    }
}
