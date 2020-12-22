using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class GetTodosItemQuery : IRequest<List<GetTodosItemQueryResult>>
    {
        public int TodoListId { get; set; }
    }

    public class GetTodosItemQueryHandler : IRequestHandler<GetTodosItemQuery, List<GetTodosItemQueryResult>>
    {
        private readonly IDbConnection dbConnection;

        public GetTodosItemQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<List<GetTodosItemQueryResult>> Handle(GetTodosItemQuery request, CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("todoListId", request.TodoListId);

            return (await dbConnection
                                .QueryAsync<GetTodosItemQueryResult>("SELECT * FROM getTodoItems_ui WHERE todoListId = @todoListId", parameters)
                    ).ToList();
        }

    }

    public class GetTodosItemQueryResult
    {
        public int Id { get; set; }
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool IsDone { get; set; }
        public bool IsEnabled { get; set; }
    }

}
