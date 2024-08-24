using MediatR;
using SkateShop.Domain.Common;
using SkateShop.Domain.Notifications;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Commands.TopBarMessages.Delete
{
    public class DeleteTopBarMessageCommandHandler : IRequestHandler<DeleteTopBarMessageCommand, Nothing>
    {
        private readonly ITopBarMessageRepository _topBarMessageRepository;
        private readonly INotificationContext _notification;

        public DeleteTopBarMessageCommandHandler(
            ITopBarMessageRepository topBarMessageRepository,
            INotificationContext notification) 
        {
            _topBarMessageRepository = topBarMessageRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(DeleteTopBarMessageCommand command, CancellationToken cancellationToken) 
        {
            var message = await _topBarMessageRepository.GetByIdAsync(command.Id);
            
            if (message == null)
            {
                _notification.AddNotFound("Mensagem não encontrada.");
                return default;
            }

            _topBarMessageRepository.Remove(message);
            await _topBarMessageRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
