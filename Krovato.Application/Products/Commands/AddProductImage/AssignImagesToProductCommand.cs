using MediatR;

namespace Krovato.Application.Products.Commands.AddProductImage
{
    public class AssignImagesToProductCommand : IRequest<Unit>
    {
        public List<Guid> ImageIds { get; set; } = [];

        public Guid ProductId { get; set; }
    }
}
