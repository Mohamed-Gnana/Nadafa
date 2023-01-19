using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Application.UserAggregate.Commands.ActivateUser
{
    public class ActivateUserCommandHandler : IRequestHandler<ActivateUserCommand, Unit>
    {
        private IUserCommandRepository _repository;

        public ActivateUserCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(request.UserId, new ActivateStrategy(), cancellationToken);
            return Unit.Value;
        }
    }
}
