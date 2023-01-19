using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class UpdateUserProfileStrategy : IStrategy
    {
        private UserProfile _userProfile;

        public UpdateUserProfileStrategy(UserProfile userProfile)
        {
            _userProfile = userProfile;
        }

        public void Execute(User user)
        {
            user.UpdateProfile(_userProfile);
        }
    }
}
