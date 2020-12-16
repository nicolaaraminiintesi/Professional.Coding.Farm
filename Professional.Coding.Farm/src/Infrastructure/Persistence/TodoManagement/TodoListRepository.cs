using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Infrastructure.Persistence.TodoManagement
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TodoListRepository(ApplicationDbContext dbContext) => this.dbContext = dbContext;

        public void Add(TodoList todoList) => dbContext.TodoLists.Add(todoList);

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();
    }
}
