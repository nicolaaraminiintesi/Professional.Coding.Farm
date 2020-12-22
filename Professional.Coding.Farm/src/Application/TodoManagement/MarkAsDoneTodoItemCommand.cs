using MediatR;
using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class MarkAsDoneTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int ListId { get; set; }
    }

    public class MarkAsDoneTodoItemCommandHandler : IRequestHandler<MarkAsDoneTodoItemCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public MarkAsDoneTodoItemCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(MarkAsDoneTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.ListId);

            todoList.MarkItemAsDone(request.Id);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }

}
