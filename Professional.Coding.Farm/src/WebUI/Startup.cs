using Professional.Coding.Farm.Application;
using Professional.Coding.Farm.Infrastructure;
using Professional.Coding.Farm.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag.Generation.Processors.Security;
using NSwag.AspNetCore;

namespace Professional.Coding.Farm.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Professional.Coding.Farm API";
                configure.Version = "v2";
                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHealthChecks("/health");

            app.UseOpenApi();
            app.UseSwaggerUi3(config =>
            {
                config.Path = "/api";
                config.SwaggerRoutes.Add(new SwaggerUi3Route("v2.0", "/swagger/v1/swagger.json"));
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
