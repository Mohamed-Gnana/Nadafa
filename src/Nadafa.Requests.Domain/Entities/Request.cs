using Nadafa.Requests.Domain.Enums;
using Nadafa.Requests.Domain.ValueObjects;
using Nadafa.SharedKernal.Domain.Entities;
using Nadafa.SharedKernal.Domain.Extensions;

namespace Nadafa.Requests.Domain.Entities
{
    public class Request: BaseEntityWithActivity
    {
        private Guid _userId;
        private string _reference;

        private PaymentEnum _paymentType;
        private RequestStatus _status;

        private List<RequestItem> _items = new();
        private List<RequestAudit> _audits = new();


        private Request() { }
        public Request(
            Guid userId,
            List<RequestItemDto> items,
            PaymentEnum paymentType = PaymentEnum.Coins)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _reference = ReferenceGenerator.Generator("req-");
            _paymentType = paymentType;
            _status = RequestStatus.Pending;
            items.ForEach(x => this.AddRequestItem(x));
        }



        public Guid UserId
        {
            get => _userId;
            private set => _userId = value;
        }

        public string Reference
        {
            get => _reference;
            private set => _reference = value;
        }

        public PaymentEnum PaymentType
        {
            get => _paymentType;
            private set => _paymentType = value;
        }

        public RequestStatus Status
        {
            get => _status;
            private set => _status = value;
        }

        public List<RequestItem> Items => _items;
        public List<RequestAudit> Audits => _audits;


        public void AddRequestItem(RequestItemDto? item)
        {
            if (item is null) return;
            _items.Add(new RequestItem(item.Weight, item.PricePerKg, item.TrashTypes));
        }

        public void UpdatePaymentType(PaymentEnum? paymentType)
        {
            if (paymentType is null || paymentType == _paymentType) return;
            _paymentType = paymentType.Value;
        }

        public void OnTheWayToPick()
        {
            if (_status == RequestStatus.OnTheWayToPick) return;
            _status = RequestStatus.OnTheWayToPick;
        }

        public void PickedAndPaid()
        {
            if (_status == RequestStatus.PickedAndPaid) return;
            _status = RequestStatus.PickedAndPaid;
        }

        public void Cancel()
        {
            if (_status == RequestStatus.Canceled) return;
            _status = RequestStatus.Canceled;
        }
    }
}
