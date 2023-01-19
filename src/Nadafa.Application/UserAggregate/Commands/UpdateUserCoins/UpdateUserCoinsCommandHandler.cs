using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdateUserCoins
{
    public class UpdateUserCoinsCommandHandler : IRequestHandler<UpdateUserCoinsCommand, Unit>
    {
        private readonly IUserCommandRepository _repository;
        private readonly IUserQueriesRepository _queryRepository;

        public UpdateUserCoinsCommandHandler(IUserCommandRepository repository, IUserQueriesRepository queryRepository)
        {
            _repository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<Unit> Handle(UpdateUserCoinsCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(request.UserId, new UpdateUserCoinsStrategy(request.Coins), cancellationToken);
            return Unit.Value;
        }
    }
}
