using Krovato.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Products.Commands.RemoveProductImages
{
    public class RemoveProductImageCommandHandler : IRequestHandler<RemoveProductImageCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;
        public RemoveProductImageCommandHandler(IKrovatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var images = await _dbContext.Images
                .Where(i => request.ImageIds.Contains(i.Id) && i.ProductId == request.ProductId)
                .ToListAsync(cancellationToken);
            
            if (images.Count != request.ImageIds.Count)
            {
                throw new KeyNotFoundException("Image not found or not assigned to the product");
            }

            foreach (var image in images)
            {
                image.ProductId = null; // Unassign the image from the product
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
