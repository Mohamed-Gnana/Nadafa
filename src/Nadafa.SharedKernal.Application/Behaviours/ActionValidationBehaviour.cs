using MediatR;
using Microsoft.AspNetCore.Http;
using Nadafa.SharedKernal.Application.Behaviours.AccessorExtension;
using Nadafa.SharedKernal.Shared.Enums;
using Nadafa.SharedKernal.Shared.Security;

namespace Nadafa.SharedKernal.Application.Behaviours;

public class ActionValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IActionValidator<TRequest, TResponse>> _actionValidators;
    private readonly IHttpContextAccessor _accessor;

    public ActionValidationBehaviour(IEnumerable<IActionValidator<TRequest, TResponse>> actionValidators,
        IHttpContextAccessor accessor)
    {
        _actionValidators = actionValidators;
        _accessor = accessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_actionValidators.Any()) return await next();
        var aborted = false;

        foreach (var actionValidator in _actionValidators)
        {
            var result = await actionValidator.Validate(request, cancellationToken);
            switch (result.Status)
            {
                case ActionValidationStatus.Unauthorized:
                    await _accessor.SendUnauthorizedAndAbort(result.Message ?? "Unauthorized");
                    aborted = true;
                    break;
                case ActionValidationStatus.Forbidden:
                    await _accessor.SendForbiddenAndAbort(result.Message ?? "Forbidden");
                    aborted = true;
                    break;
                case ActionValidationStatus.NotFound:
                    await _accessor.SendNotFoundAndAbort(result.Message ?? "Not Found");
                    aborted = true;
                    break;
                case ActionValidationStatus.Continue:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (aborted)
                return (TResponse)Activator.CreateInstance(typeof(TResponse))!;
        }

        return await next();
    }
}