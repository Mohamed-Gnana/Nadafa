using FluentValidation;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdateUserCoins
{
    public class UpdateUserCoinsCommandValidator: AbstractValidator<UpdateUserCoinsCommand>
    {
        private IUserQueriesRepository _repository;
        private User? _user;

        public UpdateUserCoinsCommandValidator(IUserQueriesRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MustAsync(BeExist).WithMessage("User does not exist");

            RuleFor(x => x.Coins)
                .Cascade(CascadeMode.Stop)
                .GreaterThan(0).WithMessage("Coins must be greater than 0");
        }

        private async Task<bool> BeExist(Guid id, CancellationToken cancellationToken)
        {
            _user = await _repository.GetUserByIdAsync(id, cancellationToken);
            return _user is not null;
        }
    }
}
