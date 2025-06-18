using Krovato.Application.Interfaces;
using Krovato.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Krovato.Persistence
{
   
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddDbContext<KrovatoDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DbConnection");
                options.UseNpgsql(connectionString);
            });

            serviceCollection.AddScoped<IKrovatoDbContext>(provider => provider.GetRequiredService<KrovatoDbContext>());
            return serviceCollection;
        }
    }
}
