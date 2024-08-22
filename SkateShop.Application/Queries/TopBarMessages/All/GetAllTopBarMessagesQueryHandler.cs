using MediatR;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Queries.TopBarMessages.All
{
    public class GetAllTopBarMessagesQueryHandler : IRequestHandler<GetAllTopBarMessagesQuery, IEnumerable<GetAllTopBarMessagesQueryResponse>>
    {
        private readonly ITopBarMessageRepository _messageRepository;

        public GetAllTopBarMessagesQueryHandler(ITopBarMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<GetAllTopBarMessagesQueryResponse>> Handle(GetAllTopBarMessagesQuery query, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetAllAsync();
            return messages.Select(m => new GetAllTopBarMessagesQueryResponse(m.Id, m.Message));
        }
    }
}
