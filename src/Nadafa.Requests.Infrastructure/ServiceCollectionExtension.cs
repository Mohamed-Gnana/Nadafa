using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.Requests.Infrastructure.EntityFramework.Repositories.CommandsRepositories;
using Nadafa.Requests.Infrastructure.EntityFramework.Repositories.QueriesRepositories;
using Nadafa.Requests.Repositories.RequestAggregate.CommandsRepositories;
using Nadafa.Requests.Repositories.RequestAggregate.QueriesRepositories;

namespace Nadafa.Requests.Infrastructure.EntityFramework
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRequestInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RequestDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(RequestDbContext).Assembly.FullName)));

            services.AddTransient<IRequestCommandsRepository, RequestCommandsRepository>();
            services.AddTransient<IRequestQueriesRepository, RequestQueriesRepository>();
            return services;
        }
    }
}
