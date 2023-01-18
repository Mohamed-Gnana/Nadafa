using Nadafa.Users.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public interface IStrategy
    {
        void Execute(User user);
    }
}
