using MediatR;
using Nadafa.Users.Application.UserAggregate.Queries.Dtos;

namespace Nadafa.Users.Application.UserAggregate.Queries.GetUsers
{
    public class GetUsersQuery: IRequest<List<UserDto>>
    {
    }
}
