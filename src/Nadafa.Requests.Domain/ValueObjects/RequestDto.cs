using Nadafa.Requests.Domain.Enums;

namespace Nadafa.Requests.Domain.ValueObjects
{
    public record RequestDto
    {
        public Guid? Id { get; set; }
        public PaymentEnum PaymentType { get; set; }
        public List<RequestItemDto> Items { get; set; } = new();
    }

    public record RequestItemDto
    {
        public Guid? Id { get; set; }
        public decimal Weight { get; set; }
        public decimal PricePerKg { get; set; }
        public TrashType TrashTypes { get; set; }
    }
}
