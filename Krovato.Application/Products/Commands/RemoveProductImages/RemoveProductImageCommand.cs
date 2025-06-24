using MediatR;

namespace Krovato.Application.Products.Commands.RemoveProductImages
{
    public class RemoveProductImageCommand : IRequest<Unit>
    {
        public List<Guid> ImageIds { get; set; } = [];

        public Guid ProductId { get; set; }
    }
}
