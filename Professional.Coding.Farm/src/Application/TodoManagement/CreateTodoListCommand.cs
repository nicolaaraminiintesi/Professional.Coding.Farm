using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Professional.Coding.Farm.Infrastructure.Persistence;
using Professional.Coding.Farm.Domain.TodoManagement;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public partial class CreateTodoListCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

    public class CreateTodoListCommandHandler : IRequestHandler<CreateTodoListCommand, int>
    {
        private readonly ITodoListRepository repository;

        public CreateTodoListCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
        {
            var entity = new TodoList(request.Title);

            repository.Add(entity);
            await repository.SaveChanges();

            return entity.Id;
        }
    }
}
