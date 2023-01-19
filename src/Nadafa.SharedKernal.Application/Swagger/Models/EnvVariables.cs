using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadafa.SharedKernal.Application.Swagger.Models
{
    public static class EnvVariables
    {
        /// <summary>
        /// 
        /// </summary>
        public static string? ENVIRONMENT_NAME = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    }
}
