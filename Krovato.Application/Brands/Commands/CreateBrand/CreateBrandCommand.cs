using MediatR;

namespace Krovato.Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public string? Description { get; set; }
    }
}
