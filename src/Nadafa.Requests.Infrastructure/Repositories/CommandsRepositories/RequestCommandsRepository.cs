using Nadafa.Requests.Domain.Builders;
using Nadafa.Requests.Domain.Enums;
using Nadafa.Requests.Domain.Strategies;
using Nadafa.Requests.Domain.ValueObjects;
using Nadafa.Requests.Repositories.RequestAggregate.CommandsRepositories;
using Nadafa.Requests.Repositories.RequestAggregate.QueriesRepositories;

namespace Nadafa.Requests.Infrastructure.EntityFramework.Repositories.CommandsRepositories
{
    public class RequestCommandsRepository : IRequestCommandsRepository
    {
        private readonly RequestDbContext _context;
        private readonly IRequestQueriesRepository _repository;

        public RequestCommandsRepository(RequestDbContext context, IRequestQueriesRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public void Cancel(Guid requestId)
        {
            var request = _repository.GetRequest(requestId);
            if (request is null) return;
            request.Cancel();
        }

        public async Task CancelAsync(Guid requestId, CancellationToken cancellationToken = default)
        {
            var request = await _repository.GetRequestAsync(requestId, cancellationToken);
            if (request is null) return;
            request.Cancel();
        }

        public Guid CreateRequest(Guid userId, PaymentEnum paymentType, List<RequestItemDto> items)
        {
            var request = new RequestFactory(userId, paymentType).WithItems(items).Build();
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request.Id;
        }

        public async Task<Guid> CreateRequestAsync(Guid userId, PaymentEnum paymentType, List<RequestItemDto> items, CancellationToken cancellationToken = default)
        {
            var request = new RequestFactory(userId, paymentType).WithItems(items).Build();
            await _context.Requests.AddAsync(request, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.Id;
        }

        public void OnTheWayToPick(Guid requestId)
        {
            var request = _repository.GetRequest(requestId);
            if (request is null) return;
            request.OnTheWayToPick();
        }

        public async Task OnTheWayToPickAsync(Guid requestId, CancellationToken cancellationToken = default)
        {
            var request = await _repository.GetRequestAsync(requestId, cancellationToken);
            if (request is null) return;
            request.OnTheWayToPick();
        }

        public void PickAndPay(Guid requestId)
        {
            var request = _repository.GetRequest(requestId);
            if (request is null) return;
            request.PickedAndPaid();
        }

        public async Task PickAndPayAsync(Guid requestId, CancellationToken cancellationToken = default)
        {
            var request = await _repository.GetRequestAsync(requestId, cancellationToken);
            if (request is null) return;
            request.PickedAndPaid();
        }

        public void Remove(Guid requestId)
        {
            var request = _repository.GetRequest(requestId);
            if (request is null) return;
            _context.Requests.Remove(request);
        }

        public async Task Remove(Guid requestId, CancellationToken cancellationToken = default)
        {
            var request = await _repository.GetRequestAsync(requestId, cancellationToken);
            if (request is null) return;
            _context.Requests.Remove(request);
        }

        public void Update(Guid requestId, IStrategy strategy)
        {
            var request = _repository.GetRequest(requestId);
            if (request is null) return;
            strategy.Execute(request);
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Guid requestId, IStrategy strategy, CancellationToken cancellationToken = default)
        {
            var request = await _repository.GetRequestAsync(requestId, cancellationToken);
            if (request is null) return;
            strategy.Execute(request);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
