using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdateUserCoins
{
    public class UpdateUserCoinsCommand: IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public int Coins { get; set; }
    }
}
