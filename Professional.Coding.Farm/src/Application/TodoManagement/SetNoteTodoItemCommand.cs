using MediatR;
using Professional.Coding.Farm.Domain.TodoManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class SetNoteTodoItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Note { get; set; }
    }

    public class SetNoteTodoItemCommandHandler : IRequestHandler<SetNoteTodoItemCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public SetNoteTodoItemCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(SetNoteTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.ListId);

            todoList.SetItemNote(request.Id, request.Note);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }

}
