using CQRS_and_Event_Sourcing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_and_Event_Sourcing.Repository
{
    public class DummyRepository
    {
        public List<Todo> Todos { get; } = new List<Todo>
        {
            new Todo{Id=1, Name="Read", Completed=true},
            new Todo{Id=2, Name="Post on twitter", Completed=true},
            new Todo{Id=3, Name="Update Business page", Completed=false},
            new Todo{Id=4, Name="Datastructure studies", Completed=true},
            new Todo{Id=5, Name="work", Completed=false},

        };
    }
}
