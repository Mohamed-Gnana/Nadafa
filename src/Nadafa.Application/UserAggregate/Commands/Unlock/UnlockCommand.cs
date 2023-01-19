using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.Unlock
{
    public class UnlockCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
    }
}
