using MediatR;

namespace Krovato.Application.Categorys.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? ParentId { get; set; }
        public string Slug { get; set; } = null!;
    }
}
