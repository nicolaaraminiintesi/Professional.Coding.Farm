using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Professional.Coding.Farm.Domain.TodoManagement;
using Professional.Coding.Farm.Application.TodoManagement;

namespace Professional.Coding.Farm.WebUI.Controllers
{
    public class TodoListsController : ApiController
    {
        [HttpGet]
        public async Task<List<GetTodosQueryResult>> Get()
            => await Mediator.Send(new GetTodosQuery());

        [HttpPost]
        public async Task<int> Create(CreateTodoListCommand command)
            => await Mediator.Send(command);

        [HttpPut]
        public async Task Update(UpdateTodoListCommand command)
            => await Mediator.Send(command);

        [HttpPost("Enable")]
        public async Task Enable(EnableTodoListCommand command)
            => await Mediator.Send(command);

        [HttpPost("Disable")]
        public async Task Disable(DisableTodoListCommand command)
            => await Mediator.Send(command);

        [HttpPost("GetItems")]
        public async Task<List<GetTodosItemQueryResult>> GetItems(GetTodosItemQuery query)
            => await Mediator.Send(query);

        [HttpPost("Item")]
        public async Task CreateItem(CreateTodoItemCommand command)
            => await Mediator.Send(command);

        [HttpPost("Item/Enable")]
        public async Task EnableItem(EnableTodoItemCommand command)
            => await Mediator.Send(command);

        [HttpPost("Item/Disable")]
        public async Task DisableItem(DisableTodoItemCommand command)
            => await Mediator.Send(command);

        [HttpPut("Item")]
        public async Task UpdateItem(UpdateTodoItemCommand command)
            => await Mediator.Send(command);

        [HttpPut("Item/AddNote")]
        public async Task AddNote(SetNoteTodoItemCommand command)
            => await Mediator.Send(command);

        [HttpPut("Item/MarkAsDone")]
        public async Task MarkAsDone(MarkAsDoneTodoItemCommand command)
            => await Mediator.Send(command);

        [HttpPut("Item/MarkAsNotDone")]
        public async Task MarkAsNotDone(MarkAsNotDoneTodoItemCommand command)
            => await Mediator.Send(command);
    }
}
