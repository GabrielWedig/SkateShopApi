using MediatR;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Queries.Messages.All
{
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, IEnumerable<GetAllMessagesQueryResponse>>
    {
        private readonly ITopBarMessageRepository _messageRepository;

        public GetAllMessagesQueryHandler(ITopBarMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<GetAllMessagesQueryResponse>> Handle(GetAllMessagesQuery query, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetAllAsync();
            return messages.Select(m => new GetAllMessagesQueryResponse(m.Id, m.Message));
        }
    }
}
