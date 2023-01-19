using MediatR;
using Nadafa.SharedKernal.Shared.Models;

namespace Nadafa.SharedKernal.Shared.Security
{
    public interface IActionValidator<in TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        Task<ActionValidatorResult> Validate(TRequest request, CancellationToken cancellationToken);
    }

    public interface IActionValidator<in TRequest>
        where TRequest : IRequest<Unit>
    {
        Task<ActionValidatorResult> Validate(TRequest request, CancellationToken cancellationToken);
    }
}
