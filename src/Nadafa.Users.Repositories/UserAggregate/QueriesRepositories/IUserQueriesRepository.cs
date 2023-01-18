using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Repositories.UserAggregate.QueriesRepositories
{
    public interface IUserQueriesRepository
    {
        List<User> GetUsers();
        User? GetUserById(Guid id);
        User? GetUserByPhoneNumber(string phoneNumber);
        User? GetUserByEmail(string email);
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User?> GetUserByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default);
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

    }
}
