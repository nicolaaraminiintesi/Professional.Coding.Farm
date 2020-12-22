using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Infrastructure.Persistence
{
    public class UseDbContextMiddleware
    {
        private readonly RequestDelegate _next;

        public UseDbContextMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext)
        {
            await _next(context);

            await dbContext.SaveChangesAsync();
        }
    }

}
