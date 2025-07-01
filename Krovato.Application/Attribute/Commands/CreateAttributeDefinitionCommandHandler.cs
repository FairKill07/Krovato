using Krovato.Application.Interfaces;
using Krovato.Domain.Attributes.Entities;
using MediatR;

namespace Krovato.Application.Attribute.Commands
{
    class CreateAttributeDefinitionCommandHandler : IRequestHandler<CreateAttributeDefinitionCommand, Guid>
    {
        private readonly IKrovatoDbContext _dbContext;
        public CreateAttributeDefinitionCommandHandler(IKrovatoDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateAttributeDefinitionCommand request, CancellationToken cancellationToken)
        {
            var attributeDefinition = new AttributeDefinition
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                DataType = request.DataType,
                Options = []
            };

            _dbContext.AttributeDefinitions.Add(attributeDefinition);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return attributeDefinition.Id;
        }
    }
}
