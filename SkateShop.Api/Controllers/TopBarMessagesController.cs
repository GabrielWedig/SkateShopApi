using MediatR;
using Microsoft.AspNetCore.Mvc;
using SkateShop.Application.Commands.TopBarMessages.Create;
using SkateShop.Application.Commands.TopBarMessages.Delete;
using SkateShop.Application.Commands.TopBarMessages.Update;
using SkateShop.Application.Queries.TopBarMessages.All;
using SkateShop.Application.Queries.TopBarMessages.ById;
using SkateShop.Infrastructure.Authentication;

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
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllTopBarMessagesQuery query)
        {
            var messages = await _mediator.Send(query);
            return Ok(messages);
        }

        [HttpGet("{id}")]
        [HasPermission(Permissions.TopBarMessages.GetById)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var message = await _mediator.Send(new GetTopBarMessageByIdQuery(id));
            return Ok(message);
        }

        [HttpPost]
        [HasPermission(Permissions.TopBarMessages.Update)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTopBarMessageCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        [HasPermission(Permissions.TopBarMessages.Update)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateTopBarMessageCommand command)
        {
            await _mediator.Send(command.WithId(id));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [HasPermission(Permissions.TopBarMessages.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteTopBarMessageCommand(id));
            return NoContent();
        }
    }
}