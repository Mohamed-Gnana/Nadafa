using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.Requests.Application;
using Nadafa.Requests.Infrastructure;
using Nadafa.Requests.Infrastructure.EntityFramework;

namespace Nadafa.Requests.Api
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRequest(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRequestApplication();
            services.AddRequestInfrastructure(configuration);
            services.AddScoped<RequestDbContext>();
            services.AddHealthChecks().AddDbContextCheck<RequestDbContext>();

            return services;
        }
    }
}