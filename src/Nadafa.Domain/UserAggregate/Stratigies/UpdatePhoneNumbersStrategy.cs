using Nadafa.Users.Domain.UserAggregate.Entities;
using Nadafa.Users.Domain.UserAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Domain.UserAggregate.Stratigies
{
    public class UpdatePhoneNumbersStrategy : IStrategy
    {
        private readonly List<PhoneEntityDto> _phones = new();

        public UpdatePhoneNumbersStrategy(List<PhoneEntityDto> phones)
        {
            _phones.AddRange(phones);
        }

        public void Execute(User user)
        {
            if (_phones.Any(x => x.IsMain) is false) throw new ArgumentException("There must be at least one main phone");
            if (_phones.Any(x => x.IsActive) is false) throw new ArgumentException("There must be at least one active phone.");

            var newPhones = _phones.Where(x => x.Id is null).ToList();
            var updatedPhones = _phones.Where(x => user.Phones.Any(y => y.PhoneNumber == x.PhoneNumber)).ToList();
            var removedPhones = user.Phones.Where(x => _phones.Any(y => y.Id == x.Id) == false).ToList();
                        
            newPhones.ForEach(x => user.AddPhone(x));
            updatedPhones.ForEach(x => user.UpdatePhone(x));
            removedPhones.ForEach(x => user.RemovePhone(x.Id));
        }
    }
}
