using FluentValidation;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandValidator: AbstractValidator<UpdateUserProfileCommand>
    {
        private IUserQueriesRepository _repository;
        private User? _user;

        public UpdateUserProfileCommandValidator(IUserQueriesRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MustAsync(BeExist).WithMessage("User does not exist");

            RuleFor(x => x.Email)
                .MustAsync(BeUniqueEmail).When(x => x.Email is not null, ApplyConditionTo.CurrentValidator)
                .WithMessage("Email already Exists");

        }

        private async Task<bool> BeExist(Guid id, CancellationToken cancellationToken)
        {
            _user = await _repository.GetUserByIdAsync(id, cancellationToken);
            return _user is not null;
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByEmailAsync(email, cancellationToken);
            return user is not null;
        }
    }
}
