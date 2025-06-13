using Krovato.Domain.Attributes.Entities;
using Krovato.Domain.Catalog.Entities;
using Krovato.Domain.Media.Entities;
using Krovato.Domain.Products.Entities;
using Krovato.Domain.Promotions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Application.Interfaces
{
    public interface IKrovatoDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<ProductVariant> ProductVariants { get; }
        DbSet<Category> Categories { get; }
        DbSet<Brand> Brands { get; }
        DbSet<AttributeDefinition> AttributeDefinitions { get; }
        DbSet<ProductAttribute> ProductAttributes { get; }
        DbSet<VariantAttribute> VariantAttributes { get; }
        DbSet<Promotion> Promotions { get; }
        DbSet<Image> Images { get; }
    }
}
