using SkateShop.Domain.Entities;
using SkateShop.Domain.Repositories;

namespace SkateShop.Infrastructure.Repositories
{
    public class TopBarMessageRepository : Repository<TopBarMessage>, ITopBarMessageRepository
    {
        public TopBarMessageRepository(DataContext context) : base(context)
        {
        }
    }
}
