namespace Krovato.Persistence.DbContexts;
public class DbInitializer
{
    public static void Initialize(KrovatoDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
