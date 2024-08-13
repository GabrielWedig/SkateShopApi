namespace SkateShop.Application.Queries.Messages.All
{
    public class GetAllMessagesQueryResponse
    {
        public GetAllMessagesQueryResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }

        public Guid Id { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
