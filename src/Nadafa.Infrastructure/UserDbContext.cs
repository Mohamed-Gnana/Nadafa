using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nadafa.SharedKernal.Infrastructure.EntityFramework;
using Nadafa.SharedKernal.Shared.CurrentUser;
using Nadafa.Users.Domain.UserAggregate.Entities;
using System.Reflection;

namespace Nadafa.Users.Infrastructure
{
    public class UserDbContext : ApplicationDbContext
    {
        public UserDbContext(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public UserDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor, accessor => CurrentUser.Id)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
    }
}
