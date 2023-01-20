using Mapster;
using MediatR;
using Nadafa.SharedKernal.Application.Exceptions;
using Nadafa.Users.Application.UserAggregate.Queries.Dtos;
using Nadafa.Users.Application.UserAggregate.Queries.Mappers;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserDto>
    {
        private readonly IUserQueriesRepository _repository;

        public GetUserProfileQueryHandler(IUserQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            UserMapper.ApplyMapping();
            var user = await _repository.GetUserByIdAsync(request.UserId, cancellationToken);
            if (user is null) throw new NotFoundException("User does not exist.");
            return user.Adapt<UserDto>();
        }
    }
}
