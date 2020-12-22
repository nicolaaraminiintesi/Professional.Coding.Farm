using MediatR;
using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class EnableTodoListCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class EnableTodoListCommandHandler : IRequestHandler<EnableTodoListCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public EnableTodoListCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(EnableTodoListCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.Id);

            todoList.Enable();

            await repository.SaveChanges();

            return Unit.Value;
        }
    }

}
