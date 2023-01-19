using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class UnlockUserStrategy : IStrategy
    {
        public void Execute(User user)
        {
            user.Unlock();
        }
    }
}
