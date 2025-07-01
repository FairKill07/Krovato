using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Persistence.Configurations.Attributes
{
    public class VariantAttributeConfiguration : IEntityTypeConfiguration<VariantAttribute>
    {
        public void Configure(EntityTypeBuilder<VariantAttribute> builder)
        {
            builder.HasKey(va => va.Id);

            builder.Property(va => va.Value)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(va => va.Variant)
                .WithMany(v => v.Attributes)
                .HasForeignKey(va => va.VariantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(va => va.AttributeDefinition)
                .WithMany()
                .HasForeignKey(va => va.AttributeDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
