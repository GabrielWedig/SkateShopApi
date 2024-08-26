using MediatR;
using SkateShop.Domain.Common;
using SkateShop.Domain.Repositories;

namespace SkateShop.Application.Queries.TopBarMessages.All
{
    public class GetAllTopBarMessagesQueryHandler : IRequestHandler<GetAllTopBarMessagesQuery, Paged<GetAllTopBarMessagesQueryResponse>>
    {
        private readonly ITopBarMessageRepository _messageRepository;

        public GetAllTopBarMessagesQueryHandler(ITopBarMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Paged<GetAllTopBarMessagesQueryResponse>> Handle(GetAllTopBarMessagesQuery query, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetAllFilteredPagedAsync(query.SearchTerm, query.Page, query.Size);

            return new Paged<GetAllTopBarMessagesQueryResponse>()
            {
                Items = messages.Items.Select(m => new GetAllTopBarMessagesQueryResponse(m.Id, m.Message)),
                Page = query.Page,
                Size = query.Size,
                Total = messages.Total
            };
        }
    }
}
