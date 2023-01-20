using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Nadafa.Requests.Infrastructure.EntityFramework
{
    public class RequestDbContextFactory : IDesignTimeDbContextFactory<RequestDbContext>
    {
        public RequestDbContext CreateDbContext(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("appsettings.json");
            var config = configBuilder.Build();
            var connectionString = config.GetValue<string>("ConnectionStrings:DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<RequestDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var httpContextAccessor = new HttpContextAccessor();

            return new RequestDbContext(optionsBuilder.Options, httpContextAccessor);
        }
    }
}
