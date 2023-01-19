using Nadafa.Users.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class UpdateUserCoinsStrategy : IStrategy
    {
        private int _coins;
        public UpdateUserCoinsStrategy(int coins)
        {
            _coins = coins;
        }
        public void Execute(User user)
        {
            user.UpdateCoins(_coins);
        }
    }
}
