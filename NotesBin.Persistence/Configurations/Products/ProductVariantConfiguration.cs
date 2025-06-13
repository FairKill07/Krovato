using Krovato.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krovato.Persistence.Configurations.Products
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(pv => pv.Id);

            builder.Property(pv => pv.Sku)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(pv => pv.Price)
                .HasColumnType("decimal(18,2)");

            builder.Property(pv => pv.Stock)
                .IsRequired();

            builder.HasOne(pv => pv.Product)
                .WithMany(p => p.Variants)
                .HasForeignKey(pv => pv.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pv => pv.Attributes)
                .WithOne(va => va.Variant)
                .HasForeignKey(va => va.VariantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pv => pv.Images)
                .WithOne(i => i.Variant)
                .HasForeignKey(i => i.VariantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
