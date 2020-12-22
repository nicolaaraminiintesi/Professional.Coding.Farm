using MediatR;
using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class DisableTodoListCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DisableTodoListCommandHandler : IRequestHandler<DisableTodoListCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public DisableTodoListCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DisableTodoListCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.Id);

            todoList.Disable();

            await repository.SaveChanges();

            return Unit.Value;
        }
    }

}
