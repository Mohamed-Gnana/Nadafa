using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
