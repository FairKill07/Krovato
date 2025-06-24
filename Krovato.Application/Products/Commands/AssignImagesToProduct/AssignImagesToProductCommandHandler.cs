using Krovato.Application.Interfaces;
using Krovato.Application.Products.Commands.AssignImagesToProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Products.Commands.AddProductImage
{
    public class AssignImagesToProductCommandHandler : IRequestHandler<AssignImagesToProductCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;
        public AssignImagesToProductCommandHandler(IKrovatoDbContext dbContext) => _dbContext = dbContext;

        public async Task<Unit> Handle(AssignImagesToProductCommand request, CancellationToken cancellationToken)
        {
            var images = await _dbContext.Images
                .Where(i => request.ImageIds.Contains(i.Id))
                .ToListAsync(cancellationToken);

            if (images.Count != request.ImageIds.Count)
            {
                throw new KeyNotFoundException("Foto not found");
            }

            foreach (var image in images)
            {
                image.ProductId = request.ProductId;
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
