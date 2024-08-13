using MediatR;

namespace SkateShop.Application.Queries.Messages.All
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<GetAllMessagesQueryResponse>>
    {
    }
}
