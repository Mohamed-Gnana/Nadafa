using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Nadafa.Users.Application.UserAggregate.Queries.Dtos;
using System.Text.Json.Serialization;

namespace Nadafa.Users.Application.UserAggregate.Queries.GetUserProfile
{
    public class GetUserProfileQuery: IRequest<UserDto>
    {
        [JsonIgnore][BindNever] public Guid UserId { get; set; }
    }
}
