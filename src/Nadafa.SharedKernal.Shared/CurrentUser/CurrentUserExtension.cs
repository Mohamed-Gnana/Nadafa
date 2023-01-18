using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Nadafa.SharedKernal.Shared.CurrentUser
{
    public static class CurrentUserExtension
    {
        public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app)
        {
            CurrentUser.InitializeHttpContextAccessor(
                app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            return app;
        }
    }
}
