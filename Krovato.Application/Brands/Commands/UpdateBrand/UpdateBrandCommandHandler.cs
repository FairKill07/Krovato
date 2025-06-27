using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krovato.Application.Interfaces;
using Krovato.Domain.Catalog.Entities;
using MediatR;

namespace Krovato.Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Unit>
    {
        private readonly IKrovatoDbContext _context;
        public UpdateBrandCommandHandler(IKrovatoDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _context.Brands.FindAsync(request.Id);
            
            if (brand == null)
            {
                throw new KeyNotFoundException($"Not Found {request.Id}");
            }

            brand.Name = request.Name;
            brand.Country = request.Country;
            brand.Description = request.Description;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
