using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.ChangePassword
{
    public class ChangePasswordCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
