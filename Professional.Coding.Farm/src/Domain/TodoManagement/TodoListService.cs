using Professional.Coding.Farm.Domain.NotificationManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public class TodoListService
    {
        private readonly ITodoListRepository repository;
        private readonly INotificationRepository notificationRepository;

        public TodoListService(ITodoListRepository todoListRepository, INotificationRepository notificationRepository)
        {
            this.repository = todoListRepository;
            this.notificationRepository = notificationRepository;
        }

        public async Task Update(int todoListId, string colourCode, string title, int? notificationDaysStartingFromNow)
        {
            TodoList todoList = await repository.GetByKey(todoListId);
            Colour colour = Colour.GetByCode(colourCode);

            todoList.Update(title, colour);

            await DisableAllNotifications(todoListId);

            if (notificationDaysStartingFromNow.HasValue)
            {
                Notification notification = new Notification(todoList.Id, notificationDaysStartingFromNow.Value);
                notificationRepository.Add(notification);
            }
        }

        private async Task DisableAllNotifications(int todoListId)
        {
            (await notificationRepository.GetEnabledByTodoListId(todoListId))
                .ForEach(n => n.Disable());
        }
    }
}
