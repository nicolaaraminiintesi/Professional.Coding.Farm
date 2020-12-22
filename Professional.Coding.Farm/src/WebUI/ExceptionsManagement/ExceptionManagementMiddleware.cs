using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.WebUI.ExceptionsManagement
{
    public class ExceptionManagementMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionManagementMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            Stream originalBodyStream = context.Response.Body;
            using (var newBody = new MemoryStream())
            {
                context.Response.Body = newBody;
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    context.Response.Clear();
                    context.Response.Body.Seek(0, SeekOrigin.Begin);

                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    string message = $"An error has occurred. Message: {ex.Message} *** StackTrace: {ex.StackTrace}";
                    await context.Response.WriteAsync(message);

                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    await newBody.CopyToAsync(originalBodyStream);
                }
            }
        }
    }

}
