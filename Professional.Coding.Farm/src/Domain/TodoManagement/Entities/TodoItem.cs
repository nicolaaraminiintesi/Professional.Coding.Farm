using Professional.Coding.Farm.Domain.Common;
using Professional.Coding.Farm.Domain.Enums;
using System;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public class TodoItem
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public bool Done { get; set; }

        public DateTime? Reminder { get; set; }

        public PriorityLevel Priority { get; set; }


        public TodoList List { get; set; }
    }
}
