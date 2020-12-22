using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Professional.Coding.Farm.Infrastructure.Persistence;
using Professional.Coding.Farm.Domain.TodoManagement;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class CreateTodoItemCommand : IRequest<Unit>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, Unit>
    {
        private readonly ITodoListRepository repository;

        public CreateTodoItemCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoList todoList = await repository.GetByKey(request.ListId);

            todoList.AddItem(request.Title);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }
}
