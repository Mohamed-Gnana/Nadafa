using MediatR;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using System.Security.Cryptography;
using System;
using Nadafa.SharedKernal.Shared.Enums;

namespace Nadafa.Users.Application.UserAggregate.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private IUserCommandRepository _repository;

        public CreateUserCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(request.Password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return await _repository.CreateUserAsync(request.PhoneNumber, savedPasswordHash, request.Name, Roles.Customer, request.Email, cancellationToken);
        }
    }
}
