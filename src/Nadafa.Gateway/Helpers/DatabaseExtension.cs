using Azure;
using Microsoft.EntityFrameworkCore;
using Nadafa.Users.Infrastructure;

namespace Nadafa.Gateway.Helpers
{
    public static class DatabaseExtension
    {
        public static async Task MigrateDatabase(this IServiceScope scope)
        {
            var userDbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
            await userDbContext.Database.MigrateAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="scope"></param>
        //public static async Task SeedDatabase(this IServiceScope scope, IWebHostEnvironment env)
        //{
        //    var settingsDbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
        //    await SettingsDbContextSeed.SeedDataAsync(settingsDbContext, env);
        //}
    }
}
