using MediatR;

namespace Nadafa.Users.Application.UserAggregate.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<Guid>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
