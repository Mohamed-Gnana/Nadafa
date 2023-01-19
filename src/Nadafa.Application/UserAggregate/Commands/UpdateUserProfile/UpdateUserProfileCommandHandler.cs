using MediatR;
using Nadafa.Users.Domain.UserAggregate.Stratigies;
using Nadafa.Users.Domain.UserAggregate.ValueObjects;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.Users.Application.UserAggregate.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, Unit>
    {
        private readonly IUserCommandRepository _repository;

        public UpdateUserProfileCommandHandler(IUserCommandRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateUserAsync(request.UserId, new UpdateUserProfileStrategy(new()
            {
                Name = request.Name,
                Email = request.Email
            }), cancellationToken);

            return Unit.Value;
        }
    }
}
