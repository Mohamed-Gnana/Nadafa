using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Application.UserAggregate.Commands.Login
{
    public class LoginCommand: IRequest<string?>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
