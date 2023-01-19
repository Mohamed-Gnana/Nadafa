using Nadafa.Users.Domain.UserAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class UpdateUserMaxAttemptsStrategy : IStrategy
    {
        private int _failedAttempts;
        private int _maxAttempts;
        public UpdateUserMaxAttemptsStrategy(int failedAttempts, int maxAttempts)
        {
            _failedAttempts = failedAttempts;
            _maxAttempts = maxAttempts;
        }

        public void Execute(User user)
        {
            user.UpdateMaxAttempts(_failedAttempts);
            if (_failedAttempts >= _maxAttempts) user.Lock();
        }
    }
}
