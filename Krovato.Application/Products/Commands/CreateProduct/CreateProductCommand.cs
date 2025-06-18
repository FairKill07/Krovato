using MediatR;

namespace Krovato.Application.Products.Commands.CreateProducts
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }
    }
}
