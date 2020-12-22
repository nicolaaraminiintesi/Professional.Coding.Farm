using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Domain.NotificationManagement
{
    public interface INotificationRepository
    {
        void Add(Notification notification);
        Task SaveChanges();
        Task<List<Notification>> GetEnabledByTodoListId(int todoListId);
    }
}
