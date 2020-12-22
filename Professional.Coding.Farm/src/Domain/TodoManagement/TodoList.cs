using Professional.Coding.Farm.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public class TodoList : Aggregate<int>
    {
        protected TodoList()
        {
            _todoItems = new List<TodoItem>();
            IsEnabled = true;
            Colour = Colour.Yellow;
        }

        public TodoList(string title) : this()
            => Title = title;

        public virtual string Title { get; protected set; }

        public virtual Colour Colour { get; protected set; }

        public virtual bool IsEnabled { get; protected set; }

        private ICollection<TodoItem> _todoItems = new List<TodoItem>();
        public virtual IEnumerable<TodoItem> TodoItems => _todoItems ??= new List<TodoItem>();

        public bool AtLeastOneItemToDo => TodoItems.Any(i => i.IsToDo);

        public void Update(string title, Colour colour)
        {
            Title = title;
            Colour = colour;
        }

        public void Disable()
        {
            if (AtLeastOneItemToDo)
                throw new InvalidOperationException($"Can't disable TodoList with id {Id} because there is at least one item to do");

            IsEnabled = false;
        }

        public void Enable()
        {
            if (IsEnabled)
                throw new InvalidOperationException($"TodoList with id {Id} already enabled");

            IsEnabled = true;
        }

        public void EnableItem(int idItem)
        {
            TodoItem item = GetItemByKey(idItem);

            if (IsItemWithTitleAlreadyPresent(item.Title))
                throw new InvalidOperationException($"There is already an item with title {item.Title} enabled");

            item.Enable();
        }
        public void DisableItem(int idItem) => GetItemByKey(idItem).Disable();

        public void AddItem(string title)
        {
            if (IsItemWithTitleAlreadyPresent(title))
                throw new InvalidOperationException($"There is already an item with title {title} enabled");

            TodoItem item = new TodoItem(this, title);
            _todoItems.Add(item);
        }

        public void UpdateItem(int idItem, string title)
        {
            if (IsItemWithTitleAlreadyPresent(title, idItem))
                throw new InvalidOperationException($"There is already an item with title {title} enabled");

            TodoItem item = GetItemByKey(idItem);
            item.Update(title);
        }

        public void SetItemNote(int idItem, string title)
        {
            TodoItem item = GetItemByKey(idItem);
            item.SetNote(title);
        }

        public void MarkItemAsDone(int idItem) 
            => GetItemByKey(idItem).MarkAsDone();

        public void MarkItemAsNotDone(int idItem)
            => GetItemByKey(idItem).MarkAsNotDone();

        private TodoItem GetItemByKey(int idItem)
        {
            TodoItem item = TodoItems.FirstOrDefault(i => i.Id == idItem);

            if (item == null)
                throw new InvalidOperationException($"TodoItem with id {idItem} not found");

            return item;
        }

        private bool IsItemWithTitleAlreadyPresent(string title, int? idItemToExclude = null)
            => TodoItems
                    .Any(i => i.IsEnabled &&
                            i.Title?.Trim().ToLower() == title?.Trim().ToLower() &&
                            (idItemToExclude == null || i.Id != idItemToExclude));
    }
}
