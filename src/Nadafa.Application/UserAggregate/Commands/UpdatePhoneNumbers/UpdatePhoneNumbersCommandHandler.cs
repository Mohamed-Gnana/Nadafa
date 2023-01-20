using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdatePhoneNumbers
{
    public class UpdatePhoneNumbersCommandHandler : IRequestHandler<UpdatePhoneNumbersCommand, Unit>
    {
        private IUserCommandRepository _repository;

        public UpdatePhoneNumbersCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePhoneNumbersCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(request.UserId, new UpdatePhoneNumbersStrategy(request.Phones), cancellationToken);
            return Unit.Value;
        }
    }
}
