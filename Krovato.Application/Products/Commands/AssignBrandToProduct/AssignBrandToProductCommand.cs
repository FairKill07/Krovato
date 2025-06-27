using MediatR;

namespace Krovato.Application.Products.Commands.AssignBrandToProduct
{
    public class AssignBrandToProductCommand : IRequest<Unit>
    {
        public Guid ProductId { get; set; }
        public Guid BrandId { get; set; }
    }
}
