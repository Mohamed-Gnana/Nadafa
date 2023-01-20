using Nadafa.Requests.Domain.Entities;
using Nadafa.Requests.Domain.Enums;

namespace Nadafa.Requests.Repositories.RequestAggregate.QueriesRepositories
{
    public interface IRequestQueriesRepository
    {
        List<Request> GetRequests();
        List<Request> GetRequestsForUser(Guid userId);
        List<Request> GetRequestsPerStatus(RequestStatus status);
        Request? GetRequest(Guid requestId);

        Task<List<Request>> GetRequestsAsync(CancellationToken cancellationToken = default);
        Task<List<Request>> GetRequestsForUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<List<Request>> GetRequestsPerStatusAsync(RequestStatus status, CancellationToken cancellationToken = default);
        Task<Request?> GetRequestAsync(Guid requestId, CancellationToken cancellationToken = default);


    }
}
