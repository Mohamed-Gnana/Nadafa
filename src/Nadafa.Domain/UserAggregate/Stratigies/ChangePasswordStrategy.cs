using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class ChangePasswordStrategy : IStrategy
    {
        private string _password;

        public ChangePasswordStrategy(string password)
        {
            _password = password;
        }

        public void Execute(User user)
        {
            user.UpdatePassword(_password);
        }
    }
}
