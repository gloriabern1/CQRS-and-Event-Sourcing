using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_and_Event_Sourcing.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static CQRS_and_Event_Sourcing.Commands.AddTodo;

namespace CQRS_and_Event_Sourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;
        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var response = await mediator.Send(new Query(id));
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody]Command command) => Ok(await mediator.Send(command));
    }
}