using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Professional.Coding.Farm.Infrastructure.Persistence;
using System;
using Professional.Coding.Farm.Domain.TodoManagement;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public partial class UpdateTodoItemCommand : IRequest
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly ITodoListRepository repository;

        public UpdateTodoItemCommandHandler(ITodoListRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {
            TodoList list = await repository.GetByKey(request.ListId);

            list.UpdateItem(request.Id, request.Title);

            await repository.SaveChanges();

            return Unit.Value;
        }
    }
}
