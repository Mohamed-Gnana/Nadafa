using Mapster;
using Nadafa.Users.Application.UserAggregate.Queries.Dtos;
using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Application.UserAggregate.Queries.Mappers
{
    public static class UserMapper
    {
        public static void ApplyMapping()
        {
            TypeAdapterConfig<User, UserDto>
                .NewConfig();
        }
    }
}
