using Nadafa.SharedKernal.Domain.Entities;
using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.Users.Domain.UserAggregate.ValueObjects;

namespace Nadafa.Users.Domain.UserAggregate.Entities
{
    public class User : BaseEntityWithActivity
    {
        private string _password;
        private string? _email;
        private string _name;
        private int _maxAttempts;
        private DateTimeOffset? _lockoutDate;
        private bool _hasToChangePassword;
        private bool _isActive;
        private Roles _role;


        // Image
        // Address

        // Business
        private int _coins;

        private List<Phone> _phones = new();
        private List<UserAudit> _audits = new();

        private User() { }
        public User(string phoneNumber, string password, string name, Roles role, string? email = null)
        {
            _id = Guid.NewGuid();
            _password = password;
            _name = name;
            _email = email;
            _maxAttempts = 0;
            _lockoutDate = null;
            _hasToChangePassword = false;
            _isActive = false;
            _role = role;

            _coins = 0;

            _phones.Add(new Phone(phoneNumber, true));
        }


        public string Password
        {
            get => _password;
            private set => _password = value;
        }

        public string? Email
        {
            get => _email;
            private set => _email = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }

        public Roles Role
        {
            get => _role;
            private set => _role = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public int MaxAttempts
        {
            get => _maxAttempts;
            private set => _maxAttempts = value;
        }

        public DateTimeOffset? LockOutEnd
        {
            get => _lockoutDate;
            private set => _lockoutDate = value;
        }

        public bool HasToChangePassword
        {
            get => _hasToChangePassword;
            private set => _hasToChangePassword = value;
        }

        public int Coins
        {
            get => _coins;
            private set => _coins = value;
        }

        public List<Phone> Phones => _phones;
        public List<UserAudit> Audits => _audits;


        // Not mapped properties
        public bool IsLocked => _lockoutDate is null || _lockoutDate > DateTimeOffset.Now;



        private void UpdateName(string? name)
        {
            if (name is null || name == _name) return;

            _name = name;
        }

        private void UpdateEmail(string? email)
        {
            if (email is null || email == _email) return;

            _email = email;
        }

        public void UpdateProfile(UserProfile userProfile)
        {
            UpdateName(userProfile.Name);
            UpdateEmail(userProfile.Email);
        }

        public void UpdatePassword(string? password)
        {
            if (password is null || password == _password) return;

            _password = password;
        }

        public void UpdateMaxAttempts(int? maxAttempt)
        {
            if (maxAttempt is null || maxAttempt == _maxAttempts) return;

            _maxAttempts = maxAttempt.Value;
        }

        public void UpdateLockEnd(DateTimeOffset? lockEnd)
        {
            if (lockEnd is null || lockEnd == _lockoutDate) return;

            _lockoutDate = lockEnd;
        }

        public void HasToChangeHisPassword()
        {
            _hasToChangePassword = !_hasToChangePassword;
        }

        public void UpdateCoins(int? coins)
        {
            if (coins is null || coins == _coins) return;

            _coins = coins.Value;
        }

        public void AddPhone(PhoneEntityDto? phone)
        {
            if (phone is null) return;
            if (_phones.Any(x => x.PhoneNumber == phone.PhoneNumber)) return;

            _phones.Add(new Phone(phone.PhoneNumber, phone.IsActive,phone.IsMain));
        }


        public void UpdatePhone(PhoneEntityDto? phone)
        {
            if (phone is null || phone.Id == default) return;
            var curPhone = _phones.FirstOrDefault(x => x.Id == phone.Id);
            if (curPhone is null) return;
            curPhone.Update(phone.PhoneNumber, phone.IsActive, phone.IsMain);
        }


        public void RemovePhone(Guid? phoneId)
        {
            if (phoneId is null) return;
            var phone = _phones.FirstOrDefault(x => x.Id == phoneId);
            if (phone is null) return;
            if (phone.IsMain && _phones.Any(x => x.IsMain && x.Id != phone.Id) == false) return;
            if (phone.IsActive && _phones.Any(x => x.IsActive && x.Id != phone.Id) == false) return;
            _phones.Remove(phone);
        }

        public void ChangeRole(Roles? role)
        {
            if (role is null || role == _role) return;
            _role = role.Value;
        }

        public void Activate()
        {
            if (_isActive is true) return;
            _isActive = true;
        }

        public void Deactivate()
        {
            if (_isActive is false) return;
            _isActive = false;
        }

        public void Lock()
        {
            if (_lockoutDate is null || _lockoutDate < DateTimeOffset.Now) return;
            _lockoutDate = DateTimeOffset.Now.AddDays(1);
        }

        public void Unlock()
        {
            if (_lockoutDate > DateTimeOffset.Now) return;
            _lockoutDate = null;
        }
        
    }
}
