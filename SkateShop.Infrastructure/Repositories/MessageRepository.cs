using SkateShop.Domain.Entities;
using SkateShop.Domain.Repositories;

namespace SkateShop.Infrastructure.Repositories
{
    public class MessageRepository : Repository<MessageBar>, IMessageRepository
    {
        public MessageRepository(DataContext context) : base(context)
        {
        }
    }
}
