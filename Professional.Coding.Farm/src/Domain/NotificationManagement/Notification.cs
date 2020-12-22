using System;
using System.Collections.Generic;
using System.Text;

namespace Professional.Coding.Farm.Domain.NotificationManagement
{
    public class Notification : Aggregate<int>
    {
        public Notification()
        {
            CreatedDate = DateTime.UtcNow;
            IsEnabled = true;
        }

        public Notification(int todoListId, int daysNumber) : this()
        {
            TodoListId = todoListId;
            DaysNumber = daysNumber;
            When = CreatedDate.AddDays(DaysNumber);
        }

        public int TodoListId { get; protected set; }
        public int DaysNumber { get; protected set; }
        public DateTime When { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public bool IsEnabled { get; protected set; }

        public void Disable() => IsEnabled = false;
    }
}
