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
        public int? NotificationDaysStartingFromNow { get; set; }
    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateTodoListCommand>
    {
        private readonly TodoListService service;

        public UpdateTodoListCommandHandler(TodoListService service)
        {
            this.service = service;
        }

        public async Task<Unit> Handle(UpdateTodoListCommand request, CancellationToken cancellationToken)
        {
            await service.Update(request.Id, request.Colour, request.Title, request.NotificationDaysStartingFromNow);
            return Unit.Value;
        }
    }
}
