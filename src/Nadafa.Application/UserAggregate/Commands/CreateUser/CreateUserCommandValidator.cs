using FluentValidation;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Application.UserAggregate.Commands.CreateUser
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        private IUserQueriesRepository _repository;

        public CreateUserCommandValidator(IUserQueriesRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .MustAsync(BeUnique).WithMessage("Phone Number already exists.");

            RuleFor(x => x.Email)
                .MustAsync(BeUniqueEmail).When(x => x.Email is not null, ApplyConditionTo.CurrentValidator)
                .WithMessage("Email already Exists");
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmailAsync(email, cancellationToken);
            return user is not null;
        }

        private async Task<bool> BeUnique(string phoneNumber, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByPhoneNumberAsync(phoneNumber, cancellationToken);
            return user is not null;
        }
    }
}
