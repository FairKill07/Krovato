using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Krovato.Domain.Media.Entities;

namespace Krovato.Persistence.Configurations.Media
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(i => i.AltText)
                .HasMaxLength(200);

            builder.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Variant)
                .WithMany(v => v.Images)
                .HasForeignKey(i => i.VariantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
