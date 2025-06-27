using Krovato.Application.Interfaces;
using Krovato.Domain.Catalog.Entities;
using MediatR;

namespace Krovato.Application.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly IKrovatoDbContext _context;
        private readonly ISlugGenerator _slugGenerator;

        public CreateCategoryCommandHandler(
            IKrovatoDbContext context,
            ISlugGenerator slugGenerator)
        {
            _context = context;
            _slugGenerator = slugGenerator;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ParentId = request.ParentId,
                Slug = _slugGenerator.GenerateSlug(request.Slug)
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
