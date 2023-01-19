using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using Nadafa.SharedKernal.Application.Swagger.Models;

namespace Nadafa.SharedKernal.Application.Swagger.Configurations
{
    public static class SwaggerConfigurationExtension
    {
        public static SwaggerConfig GetSwaggerConfig(this IConfiguration configuration)
        {
            var config = configuration.GetSection("Swagger").Get<SwaggerConfig>();
            if (config is null)
            {
                throw new Exception("Missing 'Swagger' configuration section from the appsettings.");
            }

            return config;
        }

        public static SwaggerGenOptions AddAuthorizationWithJwt(this SwaggerGenOptions options)
        {
            options.AddAuthorizationHeader();
            options.AddAuthorizationRequirement();
            return options;
        }

        public static SwaggerGenOptions AddAuthorizationHeader(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your token in the text input."
            });
            return options;
        }

        public static SwaggerGenOptions AddAuthorizationRequirement(this SwaggerGenOptions options)
        {
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
            return options;
        }
    }
}
