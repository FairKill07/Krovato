using MediatR;

namespace Krovato.Application.Categorys.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}
