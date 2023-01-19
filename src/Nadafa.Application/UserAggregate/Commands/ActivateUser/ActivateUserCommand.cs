using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.ActivateUser
{
    public class ActivateUserCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
    }
}
