using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.Users.Repositories.UserAggregate.CommandRepositories;
using System.Reflection;

namespace Nadafa.Users.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddUserApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
