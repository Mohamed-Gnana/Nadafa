using Nadafa.Requests.Domain.Enums;
using Nadafa.Requests.Domain.ValueObjects;
using Nadafa.SharedKernal.Domain.Entities;

namespace Nadafa.Requests.Domain.Entities
{
    public class RequestItem: BaseEntityWithActivity
    {
        private decimal _weight;
        private decimal _pricePerKg;
        private TrashType _trashType;

        private RequestItem() { }
        public RequestItem(decimal weight, decimal pricePerKg, TrashType trashType)
        {
            _id = Guid.NewGuid();
            _weight = weight;
            _pricePerKg = pricePerKg;
            _trashType = trashType;
        }


        public decimal Weight
        {
            get => _weight;
            private set => _weight = value;
        }

        public decimal PricePerKg
        {
            get => _pricePerKg;
            private set => _pricePerKg = value;
        }

        public TrashType TrashType
        {
            get => _trashType;
            private set => _trashType = value;
        }


        private void UpdateWeight(decimal? weight)
        {
            if (weight is null || weight == _weight) return;
            _weight = weight.Value;
        }

        private void UpdatePricePerKg(decimal? price)
        {
            if (price is null || price == _pricePerKg) return;
            _pricePerKg = price.Value;
        }

        private void UpdateTrashTypes(TrashType? trashTypes)
        {
            if (trashTypes is null) return;
            _trashType = trashTypes.Value;
        }

        public void Update(RequestItemDto? item)
        {
            if (item is null) return;
            UpdateWeight(item.Weight);
            UpdatePricePerKg(item.PricePerKg);
            UpdateTrashTypes(item.TrashTypes);
        }
    }
}
