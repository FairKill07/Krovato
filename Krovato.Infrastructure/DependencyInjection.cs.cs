using Microsoft.Extensions.DependencyInjection;
using Krovato.Application.Interfaces;
using Krovato.Infrastructure.Services;

namespace Krovato.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<ISlugGenerator, SlugifyService>();

            return services;
        }
    }
}
