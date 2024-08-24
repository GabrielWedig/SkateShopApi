namespace SkateShop.Application.Queries.TopBarMessages.ById
{
    public class GetTopBarMessageByIdQueryResponse
    {
        public GetTopBarMessageByIdQueryResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }

        public Guid Id { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
