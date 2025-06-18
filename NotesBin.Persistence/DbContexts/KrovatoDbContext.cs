using Krovato.Application.Interfaces;
using Krovato.Domain.Attributes.Entities;
using Krovato.Domain.Catalog.Entities;
using Krovato.Domain.Common.Entities;
using Krovato.Domain.Media.Entities;
using Krovato.Domain.Products.Entities;
using Krovato.Domain.Promotions.Entities;
using Krovato.Persistence.Configurations.Attributes;
using Krovato.Persistence.Configurations.Catalog;
using Krovato.Persistence.Configurations.Media;
using Krovato.Persistence.Configurations.Products;
using Krovato.Persistence.Configurations.Promotions;
using Microsoft.EntityFrameworkCore;

namespace Krovato.Persistence.DbContexts;

public class KrovatoDbContext : DbContext, IKrovatoDbContext
{
    public KrovatoDbContext(DbContextOptions<KrovatoDbContext> options)
        : base(options)
    {
    }
    public override int SaveChanges()
    {
        SetAuditFields();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetAuditFields();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void SetAuditFields()
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();

        foreach (var entry in entries)
        {
            var now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
            }
        }
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<AttributeDefinition> AttributeDefinitions => Set<AttributeDefinition>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<VariantAttribute> VariantAttributes => Set<VariantAttribute>();
    public DbSet<Promotion> Promotions => Set<Promotion>();
    public DbSet<Image> Images => Set<Image>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductVariantConfiguration());
        modelBuilder.ApplyConfiguration(new ProductAttributeConfiguration());
        modelBuilder.ApplyConfiguration(new VariantAttributeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new AttributeDefinitionConfiguration());
        modelBuilder.ApplyConfiguration(new PromotionConfiguration());
        modelBuilder.ApplyConfiguration(new ImageConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KrovatoDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
