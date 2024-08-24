using MediatR;

namespace SkateShop.Application.Queries.TopBarMessages.ById
{
    public class GetTopBarMessageByIdQuery : IRequest<GetTopBarMessageByIdQueryResponse?>
    {
        public GetTopBarMessageByIdQuery(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
