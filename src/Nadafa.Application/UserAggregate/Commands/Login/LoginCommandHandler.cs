using MediatR;
using Microsoft.Extensions.Configuration;
using Nadafa.Users.Repositories.UserAggregate.QueriesRepositories;

namespace Nadafa.Users.Application.UserAggregate.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string?>
    {
        private readonly IUserQueriesRepository _repository;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IUserQueriesRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserByPhoneNumberAsync(request.PhoneNumber, cancellationToken) ??
                    await _repository.GetUserByEmailAsync(request.PhoneNumber, cancellationToken);

            if (user is null) return null;

            return JsonWebTokenGeneration.GenerateJwtToken(_configuration, user);
        }
    }
}
