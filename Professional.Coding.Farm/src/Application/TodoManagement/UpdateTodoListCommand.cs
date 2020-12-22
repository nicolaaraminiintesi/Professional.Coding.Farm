using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Professional.Coding.Farm.Infrastructure.Persistence;
using System;
using Professional.Coding.Farm.Domain.TodoManagement;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class UpdateTodoListCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }
    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly ITodoListRepository repository;

        public UpdateTodoListCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.Id);
            Colour colour = Colour.GetByCode(request.Colour);

            todoList.Update(request.Title, colour);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }
}
