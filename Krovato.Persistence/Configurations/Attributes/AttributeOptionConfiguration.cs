using Krovato.Domain.Attributes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Krovato.Persistence.Configurations.Attributes
{
    public class AttributeOptionConfiguration : IEntityTypeConfiguration<AttributeOption>
    {
        public void Configure(EntityTypeBuilder<AttributeOption> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Translation)
                .HasMaxLength(100);

            builder.Property(x => x.SortOrder)
                .HasDefaultValue(0);

            builder.HasOne(x => x.AttributeDefinition)
                .WithMany(x => x.Options)
                .HasForeignKey(x => x.AttributeDefinitionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.AttributeDefinitionId, x.Value })
                .IsUnique(); 
        }
    }

}
