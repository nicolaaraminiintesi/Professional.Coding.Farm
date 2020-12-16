using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Professional.Coding.Farm.Infrastructure.Persistence;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace Professional.Coding.Farm.Application.TodoLists.Queries.GetTodos
{
    public class GetTodosQuery : IRequest<IEnumerable<TodoListVm>>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<TodoListVm>>
    {
        private readonly IDbConnection connection;

        public GetTodosQueryHandler(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<TodoListVm>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
            => await connection.QueryAsync<TodoListVm>("SELECT Id, Title, Colour FROM getTodoLists_ui");
    }
}
