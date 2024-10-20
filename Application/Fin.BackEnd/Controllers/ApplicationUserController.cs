using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Service.Model;
using System.Threading.Tasks;
using System;
using Pos.Core.Query;
using MediatR;
using Pos.Core.User.Command;

namespace Pos.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("[action]")]
        public async Task<ActionResult<LoginResponse>> Login(string username, string password)
        {
            try
            {
                return await _mediator.Send(new LoginUser(username,  password));
               
            }
            catch (Exception ex)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Login Failed!");
            }
        }
    }
}
