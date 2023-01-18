using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.Users.Infrastructure.Repositories.CommandsRepositories;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
                        options.UseSqlServer(
                            configuration.GetConnectionString("DefaultConnection"),
                            b => b.MigrationsAssembly(typeof(UserDbContext).Assembly.FullName)));

            services.AddTransient<IUserCommandRepository, UserCommandsRepository>();
            services.AddTransient<IUserQueriesRepository, IUserQueriesRepository>();
            return services;
        }
    }
}
