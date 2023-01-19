using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using System.Security.Cryptography;

namespace Nadafa.Users.Application.UserAggregate.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly IUserCommandRepository _repository;

        public ChangePasswordCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(request.NewPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            await _repository.UpdateUserAsync(request.UserId, new ChangePasswordStrategy(savedPasswordHash), cancellationToken);
            return Unit.Value;
        }
    }
}
