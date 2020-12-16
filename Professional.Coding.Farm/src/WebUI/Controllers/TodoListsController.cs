using Professional.Coding.Farm.Application.TodoLists.Commands.CreateTodoList;
using Professional.Coding.Farm.Application.TodoLists.Commands.DeleteTodoList;
using Professional.Coding.Farm.Application.TodoLists.Commands.UpdateTodoList;
using Professional.Coding.Farm.Application.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Professional.Coding.Farm.WebUI.Controllers
{
    public class TodoListsController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<TodoListVm>> Get() 
            => await Mediator.Send(new GetTodosQuery());

        [HttpPost]
        public async Task<int> Create(CreateTodoListCommand command) 
            => await Mediator.Send(command);

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}
