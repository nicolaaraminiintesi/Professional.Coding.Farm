using Professional.Coding.Farm.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Microsoft.Data.SqlClient;
using Professional.Coding.Farm.Domain.TodoManagement;
using Professional.Coding.Farm.Infrastructure.Persistence.TodoManagement;
using Professional.Coding.Farm.Domain.NotificationManagement;
using Professional.Coding.Farm.Infrastructure.Persistence.NotificationManagement;

namespace Professional.Coding.Farm.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                options.UseLazyLoadingProxies();
            });

            services.AddScoped<IDbConnection>(serviceProvider =>
            {
                SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
                connection.Open();

                return connection;
            });

            services.AddScoped<ITodoListRepository, TodoListRepository>();
            services.AddScoped<TodoListService, TodoListService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}
