using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Domain.UserAggregate.Stratigies;

namespace Nadafa.Users.Repositories.UserAggregate.CommandRepositories
{
    public interface IUserCommandRepository
    {
        Guid CreateUser(string phoneNumber, string password, string name, Roles role, string email);
        void UpdateUser(Guid userId, IStrategy strategy);
        void UpdateUser(User user, IStrategy strategy);
        void DeleteUser(Guid userId);
        void ActivateUser(Guid userId);
        void DeactivateUser(Guid userId);


        Task<Guid> CreateUserAsync(string phoneNumber, string password, string name, Roles role, string? email = null, CancellationToken cancellationToken = default);
        Task UpdateUserAsync(Guid userId, IStrategy strategy, CancellationToken cancellationToken = default);
        Task UpdateUserAsync(User user, IStrategy strategy, CancellationToken cancellationToken = default);
        Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task ActivateUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task DeactivateUserAsync(Guid userId, CancellationToken cancellationToken = default);

    }
}
