using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class LockUserStrategy : IStrategy
    {
        public LockUserStrategy()
        {

        }
        public void Execute(User user)
        {
            user.Lock();
        }
    }
}
