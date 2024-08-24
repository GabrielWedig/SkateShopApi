using MediatR;
using SkateShop.Domain.Common;
using SkateShop.Domain.Entities;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Commands.TopBarMessages.Create
{
    public class CreateTopBarMessageCommandHandler : IRequestHandler<CreateTopBarMessageCommand, Nothing>
    {
        private readonly ITopBarMessageRepository _topBarMessageRepository;

        public CreateTopBarMessageCommandHandler(ITopBarMessageRepository topBarMessageRepository)
        {
            _topBarMessageRepository = topBarMessageRepository;
        }

        public async Task<Nothing> Handle(CreateTopBarMessageCommand command, CancellationToken cancellationToken) 
        {
            var message = new TopBarMessage(command.Message);

            _topBarMessageRepository.Add(message);
            await _topBarMessageRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
