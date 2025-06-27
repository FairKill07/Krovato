using Krovato.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Categorys.Commands.UpdateCategory
{
    class UpdateCategoryCommandHandler: IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IKrovatoDbContext _dbContext;

        public UpdateCategoryCommandHandler(IKrovatoDbContext context) => _dbContext = context;

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(category => category.Id == request.Id , cancellationToken);

            category.Name = request.Name;
            category.ParentId = request.ParentId;
            category.Slug = request.Slug;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
