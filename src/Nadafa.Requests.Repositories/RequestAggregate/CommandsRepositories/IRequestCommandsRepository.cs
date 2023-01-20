using Nadafa.Requests.Domain.Enums;
using Nadafa.Requests.Domain.Strategies;
using Nadafa.Requests.Domain.ValueObjects;

namespace Nadafa.Requests.Repositories.RequestAggregate.CommandsRepositories
{
    public interface IRequestCommandsRepository
    {
        Guid CreateRequest(Guid userId, PaymentEnum paymentType, List<RequestItemDto> items);
        void Update(Guid requestId, IStrategy strategy);
        void Cancel(Guid requestId);
        void OnTheWayToPick(Guid requestId);
        void PickAndPay(Guid requestId);
        void Remove(Guid requestId);

        Task<Guid> CreateRequestAsync(Guid userId, PaymentEnum paymentType, List<RequestItemDto> items, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid requestId, IStrategy strategy, CancellationToken cancellationToken = default);
        Task CancelAsync(Guid requestId, CancellationToken cancellationToken = default);
        Task OnTheWayToPickAsync(Guid requestId, CancellationToken cancellationToken = default);
        Task PickAndPayAsync(Guid requestId, CancellationToken cancellationToken = default);
        Task Remove(Guid requestId, CancellationToken cancellationToken = default);
    }
}
