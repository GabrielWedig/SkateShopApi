using MediatR;
using SkateShop.Domain.Notifications;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Queries.TopBarMessages.ById
{
    public class GetTopBarMessageByIdQueryHandler : IRequestHandler<GetTopBarMessageByIdQuery, GetTopBarMessageByIdQueryResponse?>
    {
        private readonly ITopBarMessageRepository _messageRepository;
        private readonly INotificationContext _notification;

        public GetTopBarMessageByIdQueryHandler(
            ITopBarMessageRepository messageRepository,
            INotificationContext notification)
        {
            _messageRepository = messageRepository;
            _notification = notification;
        }

        public async Task<GetTopBarMessageByIdQueryResponse?> Handle(GetTopBarMessageByIdQuery query, CancellationToken cancellationToken)
        {
            var message = await _messageRepository.GetByIdAsync(query.Id);

            if (message == null)
            {
                _notification.AddNotFound("Mensagem não encontrada.");
                return default;
            }
            return new GetTopBarMessageByIdQueryResponse(message.Id, message.Message);
        }
    }
}
