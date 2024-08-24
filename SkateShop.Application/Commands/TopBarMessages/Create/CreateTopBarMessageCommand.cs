using MediatR;
using SkateShop.Domain.Common;

namespace SkateShop.Application.Commands.TopBarMessages.Create
{
    public class CreateTopBarMessageCommand : IRequest<Nothing>
    {
        public string Message { get; set; } = string.Empty;
    }
}
