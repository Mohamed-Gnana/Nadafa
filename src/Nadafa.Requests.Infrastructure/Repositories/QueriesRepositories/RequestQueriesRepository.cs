using Microsoft.EntityFrameworkCore;
using Nadafa.Requests.Domain.Entities;
using Nadafa.Requests.Domain.Enums;
using Nadafa.Requests.Repositories.RequestAggregate.QueriesRepositories;

namespace Nadafa.Requests.Infrastructure.EntityFramework.Repositories.QueriesRepositories
{
    public class RequestQueriesRepository : IRequestQueriesRepository
    {
        private readonly RequestDbContext _context;

        public RequestQueriesRepository(RequestDbContext context)
        {
            _context = context;
        }

        public Request? GetRequest(Guid requestId)
        {
            return _context.Requests
                .Include(x => x.Items)
                .FirstOrDefault(x => x.Id == requestId);
        }

        public async Task<Request?> GetRequestAsync(Guid requestId, CancellationToken cancellationToken = default)
        {
            return await _context.Requests.AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == requestId, cancellationToken);
        }

        public List<Request> GetRequests()
        {
            return _context.Requests.AsNoTracking()
                .Include(x => x.Items)
                .ToList();
        }

        public async Task<List<Request>> GetRequestsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Requests.AsNoTracking()
                .Include(x => x.Items)
                .ToListAsync(cancellationToken);
        }

        public List<Request> GetRequestsForUser(Guid userId)
        {
            return _context.Requests.AsNoTracking()
                .Include(x => x.Items)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public async Task<List<Request>> GetRequestsForUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Requests.AsNoTracking()
                .Include(x => x.Items)
                .Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public List<Request> GetRequestsPerStatus(RequestStatus status)
        {
            return _context.Requests.AsNoTracking()
               .Include(x => x.Items)
               .Where(x => x.Status == status)
               .ToList();
        }

        public async Task<List<Request>> GetRequestsPerStatusAsync(RequestStatus status, CancellationToken cancellationToken = default)
        {
            return await _context.Requests.AsNoTracking()
                .Include(x => x.Items)
                .Where(x => x.Status == status)
                .ToListAsync();
        }
    }
}
