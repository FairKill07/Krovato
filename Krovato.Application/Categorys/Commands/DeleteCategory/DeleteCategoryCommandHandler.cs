using Krovato.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Categorys.Commands.DeleteCategory
{
    class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand, Guid>
    {
        private readonly IKrovatoDbContext _dbContext;

        public DeleteCategoryCommandHandler(IKrovatoDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var affectedRows = await _dbContext.Categories
                .Where(c => c.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);

            if (affectedRows == 0)
            {
                throw new KeyNotFoundException($"Category with ID {request.Id} not found.");
            }

            return request.Id;
        }

    }
}
