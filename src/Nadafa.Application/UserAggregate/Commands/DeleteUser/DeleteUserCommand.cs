using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.DeleteUser
{
    public class DeleteUserCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
    }
}
