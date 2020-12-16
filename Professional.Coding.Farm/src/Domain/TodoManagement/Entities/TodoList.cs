using Professional.Coding.Farm.Domain.Common;
using System.Collections.Generic;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public class TodoList
    {
        protected TodoList()
        {
            Items = new List<TodoItem>();
        }

        public TodoList(string title) : this() 
        {
            Title = title;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }

        public IList<TodoItem> Items { get; set; }
    }
}
