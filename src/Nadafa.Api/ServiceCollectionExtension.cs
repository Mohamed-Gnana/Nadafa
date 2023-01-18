using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.Users.Application;
using Nadafa.Users.Infrastructure;

namespace Nadafa.Api
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUser(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUserApplication();
            services.AddUserInfrastructure(configuration);
            services.AddScoped<UserDbContext>();
            services.AddHealthChecks().AddDbContextCheck<UserDbContext>();

            return services;
        }
    }
}