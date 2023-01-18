using Nadafa.SharedKernal.Domain.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Entities
{
    public class Phone: BaseEntityWithActivity
    {
        private DateTimeOffset _addedAt;
        private string _phoneNumber;
        private bool _isActive;

        private Phone()
        {

        }

        public Phone(string phoneNumber): this()
        {
            _phoneNumber = phoneNumber;
            _addedAt = DateTimeOffset.Now;
            _isActive = true;
        }

        public DateTimeOffset AddedAt
        {
            get => _addedAt;
            private set => _addedAt = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }

        public bool IsActive
        {
            get => _isActive;
            private set => _isActive = value;
        }


        public void UpdatePhoneNumber(string? phoneNumber)
        {
            if (phoneNumber == null) return;
            if (phoneNumber == _phoneNumber) return;

            _phoneNumber = phoneNumber;
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
    }
}
