using Krovato.Domain.Catalog.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Persistence.Configurations.Catalog
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(b => b.Country)
                .HasMaxLength(100);

            builder.Property(b => b.Description)
                .HasMaxLength(500);
        }
    }

}
