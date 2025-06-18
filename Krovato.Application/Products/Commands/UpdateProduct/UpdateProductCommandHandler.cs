using Krovato.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Products.Commands.UpdateProduct
{
    class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;

        public UpdateProductCommandHandler(IKrovatoDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id , cancellationToken);
            
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found."); // I need use a custom exception here.
            }

            product.CategoryId = request.CategoryId;
            product.BrandId = request.BrandId;
            product.Name = request.Name;
            product.Description = request.Description;
            product.BasePrice = request.BasePrice;
            product.Stock = request.Stock;
            

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
