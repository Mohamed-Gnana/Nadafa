
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Nadafa.SharedKernal.Domain.Entities;
using Nadafa.SharedKernal.Domain.Extensions;

namespace Nadafa.SharedKernal.Infrastructure.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string UserId = "Id";
        private readonly Func<IHttpContextAccessor, Guid?>? _getUserId;

        public ApplicationDbContext(IHttpContextAccessor httpContextAccessor, Func<IHttpContextAccessor, Guid?>? getUserId = null)
        {
            _httpContextAccessor = httpContextAccessor;
            _getUserId = getUserId;
        }

        public ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor,
            Func<IHttpContextAccessor, Guid?>? getUserId = null) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _getUserId = getUserId;
        }

        // For Save Changes
        public async Task<int> SaveChangesAsync(Guid? userId, CancellationToken cancellationToken = new())
        {
            CheckAndUpdateEntities(userId);
            var result = base.SaveChangesAsync(cancellationToken);
            return await result;
        }

        public int SaveChanges(Guid userId)
        {
            CheckAndUpdateEntities(userId);
            var result = base.SaveChanges();
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var userId = _getUserId?.Invoke(_httpContextAccessor) ??
                         GetClaimValue(_httpContextAccessor, UserId).ToGuidOrNull();
            CheckAndUpdateEntities(userId);
            var result = base.SaveChangesAsync(cancellationToken);
            return await result;
        }

        public override int SaveChanges()
        {
            var userId = _getUserId?.Invoke(_httpContextAccessor) ??
                         GetClaimValue(_httpContextAccessor, UserId).ToGuidOrNull();
            CheckAndUpdateEntities(userId);
            var result = base.SaveChanges();
            return result;
        }


        private void CheckAndUpdateEntities(Guid? userId)
        {
            ChangeTracker
                .Entries<BaseEntityWithActivity>()
                .Where(e => e.State == EntityState.Added)
                .ToList().ForEach(entry => { entry.Entity.MarkAsCreated(userId); });
            ChangeTracker
                .Entries<BaseEntityWithActivity>()
                .Where(e => e.State == EntityState.Modified)
                .ToList().ForEach(entry => { entry.Entity.MarkAsModified(userId); });
        }

        private static string GetClaimValue(IHttpContextAccessor accessor, string key)
        {
            var user = accessor?.HttpContext?.User;
            if (user?.Identity is null || !user.Identity.IsAuthenticated) return null;

            var value = user.Claims.FirstOrDefault(x => x.Type == key)?.Value;
            return value;
        }
    }
}
