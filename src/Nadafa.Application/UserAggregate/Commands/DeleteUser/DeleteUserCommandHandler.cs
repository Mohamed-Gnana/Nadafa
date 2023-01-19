using MediatR;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Application.UserAggregate.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserCommandRepository _repository;

        public DeleteUserCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteUserAsync(request.UserId, cancellationToken);
            return Unit.Value;
        }
    }
}
