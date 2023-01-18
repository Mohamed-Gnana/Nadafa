using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.Users.Domain.UserAggregate.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Builders
{
    public class UserFactory
    {
        private string? _email;
        private string _password;
        private string _phoneNumber;
        private string _name;
        private Roles _role;

        public UserFactory(string phoneNumber, string password, string name, Roles role)
        {
            _phoneNumber = phoneNumber;
            _password = password;
            _name = name;
            _role = role;
            _email = null;
        }


        public UserFactory WithEmail(string? email)
        {
            if (email is null) return this;
            _email = email;
            return this;
        }

        public User Build()
        {
            var user = new User(_phoneNumber, _password, _name, _role, _email);
            return user;
        }
    }
}
