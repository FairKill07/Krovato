using Krovato.Domain.Promotions.Enums;

namespace Krovato.Domain.Promotions.Entities
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public PromotionTargetType AppliesToType { get; set; }
        public int AppliesToId { get; set; }
    }

}
