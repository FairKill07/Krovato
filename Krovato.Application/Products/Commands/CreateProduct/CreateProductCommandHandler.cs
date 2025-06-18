using Krovato.Application.Interfaces;
using MediatR;
using Krovato.Domain.Products.Entities;

namespace Krovato.Application.Products.Commands.CreateProducts
{
    class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IKrovatoDbContext _dbContext;

        public CreateProductCommandHandler(IKrovatoDbContext dbContext) =>_dbContext = dbContext;

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                Name = request.Name,
                Description = request.Description,
                BasePrice = request.BasePrice,
                Stock = request.Stock
            };

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
