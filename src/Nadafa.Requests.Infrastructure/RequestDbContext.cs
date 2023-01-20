using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nadafa.Requests.Domain.Entities;
using Nadafa.SharedKernal.Infrastructure.EntityFramework;
using Nadafa.SharedKernal.Shared.CurrentUser;
using System.Reflection;

namespace Nadafa.Requests.Infrastructure
{
    public class RequestDbContext: ApplicationDbContext
    {
        public RequestDbContext(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public RequestDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor, accessor => CurrentUser.Id)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Request> Requests { get; set; }
    }
}