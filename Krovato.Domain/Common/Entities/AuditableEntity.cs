using Krovato.Domain.Common.Interface;

namespace Krovato.Domain.Common.Entities
{
    public abstract class AuditableEntity : IEntity
    {
        public Guid Id { get; set; }

        //Fields for auditing logic in DbContext
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
