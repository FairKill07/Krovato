using MediatR;

namespace Krovato.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductVm?>
    {
        public Guid Id { get; set; }
    }
}
