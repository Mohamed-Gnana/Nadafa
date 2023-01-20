using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.Users.Domain.UserAggregate.ValueObjects;

namespace Nadafa.Users.Application.UserAggregate.Queries.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public Roles Role { get; set; }
        public List<PhoneEntityDto> Phones { get; set; } = new();
    }
}
