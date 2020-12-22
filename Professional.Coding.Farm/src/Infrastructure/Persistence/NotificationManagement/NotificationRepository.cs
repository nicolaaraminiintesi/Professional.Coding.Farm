using Microsoft.EntityFrameworkCore;
using Professional.Coding.Farm.Domain.NotificationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Infrastructure.Persistence.NotificationManagement
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public NotificationRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;

        public void Add(Notification notification) => dbContext.Notifications.Add(notification);

        public async Task<List<Notification>> GetEnabledByTodoListId(int todoListId)
            => await dbContext
                .Notifications
                .Where(n => n.TodoListId == todoListId && n.IsEnabled)
                .ToListAsync();

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();
    }
}
