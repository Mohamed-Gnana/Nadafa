using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Application.Exceptions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication UseExceptionHandling(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
