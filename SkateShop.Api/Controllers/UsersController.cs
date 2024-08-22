using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkateShop.Application.Commands.Users.Create;
using SkateShop.Application.Commands.Users.Login;

namespace SkateShop.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
