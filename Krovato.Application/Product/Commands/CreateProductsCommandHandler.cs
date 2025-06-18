using Krovato.Application.Interfaces;
using MediatR;
using Krovato.Domain.Products.Entities;

namespace Krovato.Application.Products.Commands
{
    class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, Guid>
    {
        private readonly IKrovatoDbContext _dbContext;

        public CreateProductsCommandHandler(IKrovatoDbContext dbContext) =>_dbContext = dbContext;

        public async Task<Guid> Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            // Create a new Product entity
            var product = new Product
            {
                Id = Guid.NewGuid(), // Generate a new unique identifier for the product
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                Name = request.Name,
                Description = request.Description,
                BasePrice = request.BasePrice,
                Stock = request.Stock
            };
            // Add the product to the DbContext
            _dbContext.Products.Add(product);
            // Save changes to the database
            await _dbContext.SaveChangesAsync(cancellationToken);
            // Return the created product's ID
            return product.Id;
        }


    }
}
