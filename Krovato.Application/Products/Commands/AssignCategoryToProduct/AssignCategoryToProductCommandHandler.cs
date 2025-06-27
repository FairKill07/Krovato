using Krovato.Application.Interfaces;
using Krovato.Domain.Catalog.Entities;
using Krovato.Domain.Products.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Products.Commands.AssignCategoryToProduct
{
    public class AssignCategoryToProductCommandHandler : IRequestHandler<AssignCategoryToProductCommand, Guid>
    {
        private readonly IKrovatoDbContext _dbContext;

        public AssignCategoryToProductCommandHandler(IKrovatoDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(AssignCategoryToProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.ProductId} not found.");
            }
            var category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken);

            product.CategoryId = request.CategoryId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
