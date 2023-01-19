using FluentValidation;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.DeactivateUser
{
    public class DeactivateUserCommandValidator: AbstractValidator<DeactivateUserCommand>
    {
        private IUserQueriesRepository _repository;
        private User? _user;

        public DeactivateUserCommandValidator(IUserQueriesRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MustAsync(BeExist).WithMessage("User does not exist")
                .Must(x => _user!.IsActive).WithMessage("User must be active.");

        }

        private async Task<bool> BeExist(Guid id, CancellationToken cancellationToken)
        {
            _user = await _repository.GetUserByIdAsync(id, cancellationToken);
            return _user is not null;
        }
    }
}
