using Microsoft.EntityFrameworkCore;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Infrastructure.Repositories.QueriesRepositories
{
    public class UserQueriesRepository : IUserQueriesRepository
    {
        private UserDbContext _context;

        public UserQueriesRepository(UserDbContext context)
        {
            _context = context;
        }
        public User? GetUserByEmail(string email)
        {
            return _context.Users.Include(x => x.Phones).FirstOrDefault(x => x.Email == email);
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await _context.Users.Include(x => x.Phones).FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public User? GetUserById(Guid id)
        {
            return _context.Users.Include(x => x.Phones).FirstOrDefault(x => x.Id == id);
        }

        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.Include(x => x.Phones).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public User? GetUserByPhoneNumber(string phoneNumber)
        {
            return _context.Users.Include(x => x.Phones).FirstOrDefault(x => x.Phones.Any(y => y.PhoneNumber == phoneNumber));
        }

        public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Users.Include(x => x.Phones).FirstOrDefaultAsync(x => x.Phones.Any(y => y.PhoneNumber == phoneNumber), cancellationToken);
        }

        public List<User> GetUsers()
        {
            return _context.Users.Include(x => x.Phones).ToList();
        }

        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users.Include(x => x.Phones).ToListAsync();
        }
    }
}
