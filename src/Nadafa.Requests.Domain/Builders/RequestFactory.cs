using Nadafa.Requests.Domain.Entities;
using Nadafa.Requests.Domain.Enums;
using Nadafa.Requests.Domain.ValueObjects;

namespace Nadafa.Requests.Domain.Builders
{
    public class RequestFactory
    {
        private Guid _userId { get; set; }
        private PaymentEnum _paymentType { get; set; }
        private List<RequestItemDto> _items { get; set; } = new();

        public RequestFactory(
            Guid userId,
            PaymentEnum paymentType)
        {
            _userId = userId;
            _paymentType = paymentType;
        }

        public RequestFactory WithItems(List<RequestItemDto> items)
        {
            if (items == null || items.Count == 0) return this;
            _items.AddRange(items);
            return this;
        }


        public Request Build()
        {
            var request = new Request(_userId, _items, _paymentType);
            return request;
        }
    }
}
