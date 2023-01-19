using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.Unlock
{
    public class UnlockCommandHandler : IRequestHandler<UnlockCommand, Unit>
    {
        private IUserCommandRepository _repository;

        public UnlockCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UnlockCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(request.UserId, new UnlockUserStrategy(), cancellationToken);
            return Unit.Value;
        }
    }
}
