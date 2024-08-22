namespace SkateShop.Application.Queries.TopBarMessages.All
{
    public class GetAllTopBarMessagesQueryResponse
    {
        public GetAllTopBarMessagesQueryResponse(Guid id, string message)
        {
            Id = id;
            Message = message;
        }

        public Guid Id { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
