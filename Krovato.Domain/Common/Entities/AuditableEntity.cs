using Krovato.Domain.Common.Interface;

namespace Krovato.Domain.Common.Entities
{
    public abstract class AuditableEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }


}
