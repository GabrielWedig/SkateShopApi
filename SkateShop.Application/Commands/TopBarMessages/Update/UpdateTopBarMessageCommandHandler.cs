using MediatR;
using SkateShop.Domain.Common;
using SkateShop.Domain.Notifications;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Commands.TopBarMessages.Update
{
    public class UpdateTopBarMessageCommandHandler : IRequestHandler<UpdateTopBarMessageCommand, Nothing>
    {
        private readonly ITopBarMessageRepository _topBarMessageRepository;
        private readonly INotificationContext _notification;

        public UpdateTopBarMessageCommandHandler(
            ITopBarMessageRepository topBarMessageRepository,
            INotificationContext notification) 
        {
            _topBarMessageRepository = topBarMessageRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(UpdateTopBarMessageCommand command, CancellationToken cancellationToken) 
        {
            var message = await _topBarMessageRepository.GetByIdAsync(command.Id);
            
            if (message == null)
            {
                _notification.AddNotFound("Mensagem não encontrada.");
                return default;
            }

            if (!string.IsNullOrEmpty(command.Message))
            {
                message.Message = command.Message;
            }

            _topBarMessageRepository.Update(message);
            await _topBarMessageRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
