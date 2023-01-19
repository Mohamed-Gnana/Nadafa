using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Nadafa.SharedKernal.Application.Swagger.Configurations;
using Nadafa.SharedKernal.Application.Swagger.Filters;

namespace Nadafa.SharedKernal.Application.Swagger
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBaseSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSwaggerConfig();

            if (!config.Enabled) return services;
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.FullName);
                c.OperationFilter<SwaggerFileOperationFilter>();
                c.MapType<DateTime>(() => new OpenApiSchema { Type = "string", Format = "date" });
                c.AddAuthorizationWithJwt();
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        public static WebApplication UseBaseSwagger(this WebApplication app, IConfiguration configuration)
        {
            var config = configuration.GetSwaggerConfig();

            if (!config.Enabled) return app;
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var depth = config.HideModels ? -1 : 1;
                c.DefaultModelsExpandDepth(depth); // Disable swagger schemas at bottom
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                // c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });

            return app;
        }
    }
}
