using Mapster;
using MediatR;
using Nadafa.Users.Application.UserAggregate.Queries.Dtos;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Queries.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserQueriesRepository _repostiory;

        public GetUsersQueryHandler(IUserQueriesRepository repostiory)
        {
            _repostiory = repostiory;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repostiory.GetUsersAsync(cancellationToken);
            return users.Adapt<List<UserDto>>();
        }
    }
}
