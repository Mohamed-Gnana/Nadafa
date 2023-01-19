using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.DeactivateUser
{
    public class DeactivateUserCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
    }
}
