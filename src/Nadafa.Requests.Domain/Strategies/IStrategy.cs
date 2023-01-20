using Nadafa.Requests.Domain.Entities;

namespace Nadafa.Requests.Domain.Strategies
{
    public interface IStrategy
    {
        void Execute(Request request);
    }
}
