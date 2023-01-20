using Nadafa.SharedKernal.Domain.Entities;

namespace Nadafa.Users.Domain.UserAggregate.Entities
{
    public class Phone: BaseEntityWithActivity
    {
        private DateTimeOffset _addedAt;
        private string _phoneNumber;
        private bool _isActive;
        private bool _isMain;

        private Phone()
        {

        }

        public Phone(string phoneNumber, bool isActive = true, bool isMain = false): this()
        {
            _phoneNumber = phoneNumber;
            _addedAt = DateTimeOffset.Now;
            _isActive = isActive;
            _isMain = isMain;
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

        public bool IsMain
        {
            get => _isMain;
            private set => _isMain = value;
        }


        public void Update(string? phoneNumber, bool isActive = true, bool isMain = false)
        {
            UpdatePhoneNumber(phoneNumber);
            UpdateActive(isActive);
            UpdateMain(isMain);
        }

        public void UpdatePhoneNumber(string? phoneNumber)
        {
            if (phoneNumber == null) return;
            if (phoneNumber == _phoneNumber) return;

            _phoneNumber = phoneNumber;
        }

        public void UpdateActive(bool? isActive)
        {
            if (isActive is null || _isActive == isActive) return;
            _isActive = isActive.Value;
        }

        public void UpdateMain(bool? isMain)
        {
            if (isMain is null || _isMain == isMain) return;
            _isMain = isMain.Value;
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

        public void UpgradeToMain()
        {
            if (_isMain is true) return;
            _isMain = true;
        }

        public void RemoveMain()
        {
            if (_isMain is false) return;
            _isMain = false;
        }
    }
}
