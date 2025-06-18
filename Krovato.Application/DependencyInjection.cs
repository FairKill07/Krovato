using System.Reflection;
using Krovato.Application.Common.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Krovato.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>)); 

            //services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() }); // Validator for commands and queries

            return services;
        }
    }
}
