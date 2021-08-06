using CQRS_and_Event_Sourcing.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_and_Event_Sourcing.Queries
{
    public class Query : IRequest<Response>
    {
        public Query(int id)
        {
            this.Id = id;
        }
        public int Id { get; }
    }


    public class Response
    {
        public Response(int id, string name, bool complete)
        {
            this.Id = id;
            this.Name = name;
            this.Completed = complete;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed
        {
            get; set;
        }
    }
    //this is the conaintener that will hold all the query, handler and response for this action
    public static class GetTodoById
    {

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly DummyRepository _dummyRepository;
            public Handler(DummyRepository dummyRepository)
            {
                _dummyRepository = dummyRepository;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                //All the business logic will be here

                var todo = _dummyRepository.Todos.FirstOrDefault(x => x.Id == request.Id);
                return todo == null ? null : new Response(todo.Id, todo.Name, todo.Completed);
            
            }
        }
    }
}
