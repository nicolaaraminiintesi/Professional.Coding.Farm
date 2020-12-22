using MediatR;
using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class DisableTodoItemCommand : IRequest<Unit>
    {
        public int ListId { get; set; }
        public int Id { get; set; }
    }

    public class DisableTodoItemCommandHandler : IRequestHandler<DisableTodoItemCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public DisableTodoItemCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DisableTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.ListId);

            todoList.DisableItem(request.Id);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }

}
