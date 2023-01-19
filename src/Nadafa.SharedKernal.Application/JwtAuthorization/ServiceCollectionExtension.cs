using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Nadafa.SharedKernal.Shared.CurrentUser;
using Nadafa.SharedKernal.Shared.JwtConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Application.JwtAuthorization
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBaseAuthorization(this IServiceCollection services,
        IConfiguration configuration)
        {
            var config = configuration.GetSection("UserClientConfig").Get<UserClientConfig>();


            #region Identity Configuration

            services.AddAuthorization();
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var signingKey = Convert.FromBase64String(config.Jwt.Key!);
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier,
                    ValidateIssuer = true,
                    ValidIssuer = config.Jwt.Issuer,
                    ValidateAudience = true,
                    ValidAudience = config.Jwt.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey)
                };
            });

            #endregion

            return services;
        }

        public static WebApplication UseBaseAuthorization(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseCurrentUser();

            return app;
        }
    }
}
