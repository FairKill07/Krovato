using Krovato.Application.Interfaces;
using MediatR;

namespace Krovato.Application.Products.Commands.AssignBrandToProduct
{
    public class AssignBrandToProductCommandHandler : IRequestHandler<AssignBrandToProductCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;

        public AssignBrandToProductCommandHandler(IKrovatoDbContext context) => _dbContext = context;

        public async Task<Unit> Handle(AssignBrandToProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(request.ProductId);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
            }
            
            var brand = await _dbContext.Brands.FindAsync(request.BrandId);
            
            if (brand == null)
            {
                throw new KeyNotFoundException($"Brand with ID {request.BrandId} not found.");
            }
           
            product.BrandId = request.BrandId;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
