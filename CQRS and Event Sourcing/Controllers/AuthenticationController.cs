using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_and_Event_Sourcing.Models;
using JWTAuthenticationManager.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_and_Event_Sourcing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJWTAuthenticationManager jWTAuthenticationManager;
        public AuthenticationController(IJWTAuthenticationManager _jWTAuthenticationManager)
        {
            jWTAuthenticationManager = _jWTAuthenticationManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] Usercred usercred)
        {
            var token = jWTAuthenticationManager.Authenticate(usercred.username, usercred.password);

            if (token != null) return Ok(token);
            return Unauthorized();
        }
    }
}