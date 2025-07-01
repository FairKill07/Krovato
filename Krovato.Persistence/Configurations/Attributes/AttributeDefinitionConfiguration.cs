using Krovato.Domain.Attributes.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Persistence.Configurations.Attributes
{
    public class AttributeDefinitionConfiguration : IEntityTypeConfiguration<AttributeDefinition>
    {
        public void Configure(EntityTypeBuilder<AttributeDefinition> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }

}
