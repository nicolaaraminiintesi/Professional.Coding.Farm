using Professional.Coding.Farm.Domain.Common;
using System;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public class TodoItem : Entity
    {
        protected TodoItem()
        {
            IsEnabled = true;
            IsDone = false;
        }

        public TodoItem(TodoList todoList, string title) : this()
        {
            TodoList = todoList;
            SetTitle(title);
        }

        public virtual int Id { get; protected set; }

        public virtual int TodoListId { get; protected set; }

        public virtual string Title { get; protected set; }

        public virtual string Note { get; protected set; }

        public virtual bool IsDone { get; protected set; }

        public virtual bool IsEnabled { get; protected set; }

        public virtual TodoList TodoList { get; protected set; }

        public bool IsToDo => IsDone == false && IsEnabled;

        public void Update(string title) => SetTitle(title);
        public void SetNote(string note) => Note = note;
        public void MarkAsDone() => IsDone = true;
        public void MarkAsNotDone() => IsDone = false;

        private void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new InvalidOperationException("Title cannot be empty for TodoItem");

            Title = title;
        }

        public void Enable() => IsEnabled = true;
        public void Disable() => IsEnabled = false;
    }
}
