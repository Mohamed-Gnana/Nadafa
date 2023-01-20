using FluentValidation;
using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdatePhoneNumbers
{
    public class UpdatePhoneNumbersCommandValidator: AbstractValidator<UpdatePhoneNumbersCommand>
    {
        private readonly IUserQueriesRepository _repository;
        private User? _user;
        public UpdatePhoneNumbersCommandValidator(IUserQueriesRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.UserId)
               .Cascade(CascadeMode.Stop)
               .NotNull()
               .NotEmpty()
               .MustAsync(BeExist).WithMessage("User does not exist")
               .Must(x => _user!.IsActive is false).WithMessage("User must be deactive.")
               .DependentRules(() =>
               {
                   RuleFor(x => x.Phones)
                        .Cascade(CascadeMode.Stop)
                        .NotNull()
                        .NotEmpty()
                        .Must(x => x.Any(x => x.IsActive)).WithMessage("There must exist at least one active phone.")
                        .Must(x => x.Any(x => x.IsMain)).WithMessage("There must exist at least one main phone.");
               });
 
        }

        private async Task<bool> BeExist(Guid id, CancellationToken cancellationToken)
        {
            _user = await _repository.GetUserByIdAsync(id, cancellationToken);
            return _user is not null;
        }
    }
}
