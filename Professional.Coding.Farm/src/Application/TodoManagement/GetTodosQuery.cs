using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Threading;

namespace Professional.Coding.Farm.Application.TodoManagement
{
    public class GetTodosQuery : IRequest<List<GetTodosQueryResult>>
    {
    }

    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<GetTodosQueryResult>>
    {
        private readonly IDbConnection dbConnection;

        public GetTodosQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<List<GetTodosQueryResult>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
            => (await dbConnection
                                .QueryAsync<GetTodosQueryResult>("SELECT * FROM getTodoLists_ui")
                    ).ToList();

    }

    public class GetTodosQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Colour { get; set; }
        public bool IsEnabled { get; set; }
    }

}
