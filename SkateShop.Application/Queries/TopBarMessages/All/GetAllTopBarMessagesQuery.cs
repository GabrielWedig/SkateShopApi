using MediatR;

namespace SkateShop.Application.Queries.TopBarMessages.All
{
    public class GetAllTopBarMessagesQuery : IRequest<IEnumerable<GetAllTopBarMessagesQueryResponse>>
    {
    }
}
