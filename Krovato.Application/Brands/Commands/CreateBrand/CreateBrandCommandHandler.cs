using Krovato.Application.Interfaces;
using Krovato.Domain.Catalog.Entities;
using MediatR;

namespace Krovato.Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Unit>
    {
        private readonly IKrovatoDbContext _context;
        public CreateBrandCommandHandler(IKrovatoDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Country = request.Country,
                Description = request.Description
            };

            _context.Brands.Add(brand);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }


    }
}
