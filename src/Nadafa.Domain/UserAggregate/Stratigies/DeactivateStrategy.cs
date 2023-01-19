using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class DeactivateStrategy : IStrategy
    {
        public void Execute(User user)
        {
            user.Deactivate();
        }
    }
}
