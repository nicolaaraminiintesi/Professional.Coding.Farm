using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.WebUI.ExceptionsManagement
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseExceptionManagement(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<ExceptionManagementMiddleware>();
            return applicationBuilder;
        }
    }
}
