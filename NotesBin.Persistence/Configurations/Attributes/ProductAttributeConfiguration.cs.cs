using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Persistence.Configurations.Attributes
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.HasKey(pa => pa.Id);

            builder.Property(pa => pa.Value)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(pa => pa.Product)
                .WithMany(p => p.Attributes)
                .HasForeignKey(pa => pa.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pa => pa.AttributeDefinition)
                .WithMany()
                .HasForeignKey(pa => pa.AttributeDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
