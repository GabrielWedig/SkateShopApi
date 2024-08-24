using MediatR;
using SkateShop.Domain.Common;

namespace SkateShop.Application.Queries.TopBarMessages.All
{
    public class GetAllTopBarMessagesQuery : IRequest<Paged<GetAllTopBarMessagesQueryResponse>>
    {
        public int? Page { get; set; }

        public int? Size { get; set; }
    }
}
