using Microsoft.EntityFrameworkCore;
using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.Users.Domain.UserAggregate.Builders;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;

namespace Nadafa.Users.Infrastructure.Repositories.CommandsRepositories
{
    public class UserCommandsRepository : IUserCommandRepository
    {
        private UserDbContext _context;

        public UserCommandsRepository(UserDbContext context)
        {
            _context = context;
        }

        public void ActivateUser(Guid userId)
        {
            var user = _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefault(x => x.Id == userId);
            if (user is null) return;
            user.Activate();
            _context.SaveChanges();
        }

        public async Task ActivateUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null) return;
            user.Activate();
            await _context.SaveChangesAsync();
        }

        public Guid CreateUser(string phoneNumber, string password, string name, Roles role, string email)
        {
            var user = new UserFactory(phoneNumber, password, name, role).WithEmail(email).Build();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public async Task<Guid> CreateUserAsync(string phoneNumber, string password, string name, Roles role, string? email = null, CancellationToken cancellationToken = default)
        {
            var user = new UserFactory(phoneNumber, password, name, role).WithEmail(email).Build();
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }

        public void DeactivateUser(Guid userId)
        {
            var user = _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefault(x => x.Id == userId);
            if (user is null) return;
            user.Deactivate();
            _context.SaveChanges();
        }

        public async Task DeactivateUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefaultAsync(x => x.Id == userId);
            if (user is null) return;
            user.Deactivate();
            await _context.SaveChangesAsync();
        }

        public void DeleteUser(Guid userId)
        {
            var user = _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefault(x => x.Id == userId);
            if (user is null) return;
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (user is null) return;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void UpdateUser(Guid userId, IStrategy strategy)
        {
            var user = _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefault(x => x.Id == userId);
            if (user is null) return;
            strategy.Execute(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user, IStrategy strategy)
        {
            strategy.Execute(user);
            _context.SaveChanges();
        }

        public async Task UpdateUserAsync(Guid userId, IStrategy strategy, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users
                .Include(x => x.Phones)
                .Include(x => x.Audits)
                .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
            if (user is null) return;
            strategy.Execute(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateUserAsync(User user, IStrategy strategy, CancellationToken cancellationToken = default)
        {
            strategy.Execute(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
