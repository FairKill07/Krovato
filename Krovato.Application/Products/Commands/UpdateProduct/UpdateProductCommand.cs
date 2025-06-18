using MediatR;

namespace Krovato.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand :IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }
    }
}
