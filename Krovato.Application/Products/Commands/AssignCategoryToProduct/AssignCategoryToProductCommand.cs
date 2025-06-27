using MediatR;

namespace Krovato.Application.Products.Commands.AssignCategoryToProduct
{
    public class AssignCategoryToProductCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
