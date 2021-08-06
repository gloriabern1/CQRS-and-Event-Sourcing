using CQRS_and_Event_Sourcing.Models;
using CQRS_and_Event_Sourcing.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_and_Event_Sourcing.Commands
{
    public static class AddTodo
    {
        //command
        public class Command : IRequest<int>
        {
            //public Command(string name)
            //{
            //    this.Name = name;
            //}
            public string Name { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            //injecting dummy repository
            private readonly DummyRepository dummyRepository;
            public Handler(DummyRepository dummyRepository)
            {
                this.dummyRepository = dummyRepository;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                dummyRepository.Todos.Add(new Todo { Id = 10, Name = request.Name, Completed = false });
                return 10;
            
            }
        }
    }
}
