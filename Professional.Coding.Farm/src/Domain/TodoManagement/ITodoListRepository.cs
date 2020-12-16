using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Domain.TodoManagement
{
    public interface ITodoListRepository
    {
        void Add(TodoList todoList);
        Task SaveChanges();
    }
}
