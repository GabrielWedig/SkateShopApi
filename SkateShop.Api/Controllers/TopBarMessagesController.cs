using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkateShop.Application.Queries.Messages.All;

namespace SkateShop.Api.Controllers
{
    [ApiController]
    [Route("api/top-bar")]
    public class TopBarMessagesController : Controller
    {
        private readonly IMediator _mediator;

        public TopBarMessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var messages = await _mediator.Send(new GetAllMessagesQuery());
            return Ok(messages);
        }
    }
}
