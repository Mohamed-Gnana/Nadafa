namespace Nadafa.Users.Domain.UserAggregate.ValueObjects
{
    public record PhoneEntityDto
    {
        public Guid? Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsMain { get; set; }
    }
}
