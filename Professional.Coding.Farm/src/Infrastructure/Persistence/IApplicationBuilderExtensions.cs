using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Professional.Coding.Farm.Infrastructure.Persistence
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDbContext(this IApplicationBuilder thisApplicationBuilder) 
        {
            thisApplicationBuilder.UseMiddleware<UseDbContextMiddleware>();
            return thisApplicationBuilder;
        }
    }
}
