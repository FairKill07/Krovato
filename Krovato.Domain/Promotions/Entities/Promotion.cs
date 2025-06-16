using Krovato.Domain.Common.Entities;
using Krovato.Domain.Promotions.Enums;

namespace Krovato.Domain.Promotions.Entities
{
    public class Promotion: AuditableEntity
    {
        public string Name { get; set; } = null!;

        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }

        public PromotionTargetType AppliesToType { get; set; }
        public int AppliesToId { get; set; }
    }

}
