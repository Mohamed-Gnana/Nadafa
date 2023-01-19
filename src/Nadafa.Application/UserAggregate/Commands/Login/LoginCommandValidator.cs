using FluentValidation;
using Microsoft.Extensions.Configuration;
using Nadafa.SharedKernal.Shared.JwtConfig;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;
using System.Security.Cryptography;
using System.Threading;

namespace Nadafa.Users.Application.UserAggregate.Commands.Login
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {
        private readonly IUserQueriesRepository _repository;
        private readonly IUserCommandRepository _commandRepository;
        private readonly IConfiguration _configuration;
        private User? _user;

        public LoginCommandValidator(IUserQueriesRepository repository, IUserCommandRepository commandRepository, IConfiguration configuration)
        {
            _repository = repository;
            _commandRepository = commandRepository;
            _configuration = configuration;

            var config = configuration.GetSection("UserClientConfig").Get<UserClientConfig>();

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .MustAsync(BeExist).WithMessage("The phone number or email you entered does not exist.")
                .Must(BeActive).WithMessage("The account is deactivate, please contact the adminstrator.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password)
                    .NotNull()
                    .NotEmpty()
                    .MustAsync((password, cancellationToken) => BeCorrectPassword(password, cancellationToken, config)).WithMessage($"Password is invalid. Your account will be locked after {config.Jwt.MaxFailedAccessAttempts - _user!.MaxAttempts} attempts");
                });
        }

        private async Task<bool> BeCorrectPassword(string password, CancellationToken cancellationToken, UserClientConfig config)
        {
            string savedPassword = _user!.Password;
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    await _commandRepository.UpdateUserAsync(_user, new UpdateUserMaxAttemptsStrategy(_user.MaxAttempts + 1, config.Jwt.MaxFailedAccessAttempts), cancellationToken);
                    return false;
                }
            }

            await _commandRepository.UpdateUserAsync(_user, new UpdateUserMaxAttemptsStrategy(0, config.Jwt.MaxFailedAccessAttempts), cancellationToken);
            return true;
        }

        private bool BeActive(string arg)
        {
            return _user!.IsActive;
        }

        private async Task<bool> BeExist(string phoneNumberOrEmail, CancellationToken cancellationToken)
        {
            _user = await _repository.GetUserByPhoneNumberAsync(phoneNumberOrEmail, cancellationToken) ??
                await _repository.GetUserByEmailAsync(phoneNumberOrEmail, cancellationToken);

            return _user is not null;
        }
    }
}
