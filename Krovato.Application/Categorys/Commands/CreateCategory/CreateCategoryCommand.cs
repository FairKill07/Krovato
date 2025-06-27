using MediatR;

namespace Krovato.Application.Categorys.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public string Slug { get; set; } = null!;
    }
}
