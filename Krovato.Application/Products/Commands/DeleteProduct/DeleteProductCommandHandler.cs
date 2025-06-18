using Krovato.Application.Interfaces;
using MediatR;

namespace Krovato.Application.Products.Commands.DeleteProduct
{
    class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;

        public DeleteProductCommandHandler(IKrovatoDbContext dbContext) =>_dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Find the product by ID
            var product = await _dbContext.Products.FindAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found."); // I need use a custom exception here.
            }

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
