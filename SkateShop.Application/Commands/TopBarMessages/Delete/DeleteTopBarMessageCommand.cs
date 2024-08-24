using MediatR;
using SkateShop.Domain.Common;

namespace SkateShop.Application.Commands.TopBarMessages.Delete
{
    public class DeleteTopBarMessageCommand : IRequest<Nothing>
    {
        public DeleteTopBarMessageCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
