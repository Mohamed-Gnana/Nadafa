using FluentValidation;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Application.UserAggregate.Commands.ActivateUser
{
    public class ActivateUserCommandValidator: AbstractValidator<ActivateUserCommand>
    {
        private IUserQueriesRepository _repository;
        private User? _user;

        public ActivateUserCommandValidator(IUserQueriesRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .MustAsync(BeExist).WithMessage("User does not exist")
                .Must(x => _user!.IsActive is false).WithMessage("User must be deactive.");

        }

        private async Task<bool> BeExist(Guid id, CancellationToken cancellationToken)
        {
            _user = await _repository.GetUserByIdAsync(id, cancellationToken);
            return _user is not null;
        }
    }
}
