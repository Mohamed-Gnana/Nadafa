using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.SharedKernal.Application;
using Nadafa.SharedKernal.Infrastructure.EntityFramework;

namespace Nadafa.SharedKernal.Api
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSharedKernal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
