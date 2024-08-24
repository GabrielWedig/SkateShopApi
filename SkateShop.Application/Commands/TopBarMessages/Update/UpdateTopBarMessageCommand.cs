using MediatR;
using SkateShop.Domain.Common;
using System.Text.Json.Serialization;

namespace SkateShop.Application.Commands.TopBarMessages.Update
{
    public class UpdateTopBarMessageCommand : IRequest<Nothing>
    {
        public UpdateTopBarMessageCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }

        [JsonIgnore]
        public Guid Id { get; set; }

        public string? Message { get; set; }
    }
}
