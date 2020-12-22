using MediatR;
using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class EnableTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int ListId { get; set; }
    }

    public class EnableTodoItemCommandHandler : IRequestHandler<EnableTodoItemCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public EnableTodoItemCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(EnableTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.ListId);

            todoList.EnableItem(request.Id);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }

}
