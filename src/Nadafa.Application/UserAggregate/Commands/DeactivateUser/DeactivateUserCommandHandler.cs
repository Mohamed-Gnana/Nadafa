using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.DeactivateUser
{
    public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, Unit>
    {
        private IUserCommandRepository _repository;

        public DeactivateUserCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(request.UserId, new DeactivateStrategy(), cancellationToken);
            return Unit.Value;
        }
    }
}
