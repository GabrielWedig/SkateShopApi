using Microsoft.EntityFrameworkCore;
using SkateShop.Domain.Entities;
using SkateShop.Domain.Repositories;
using SkateShop.Infrastructure.Extensions;

namespace SkateShop.Infrastructure.Repositories
{
    public class TopBarMessageRepository : Repository<TopBarMessage>, ITopBarMessageRepository
    {
        public TopBarMessageRepository(DataContext context) : base(context)
        {
        }

        public async Task<(List<TopBarMessage> Items, int Count)> GetAllFilteredPagedAsync(string searchTerm, int page, int size)
        {
            var filtered = await Query
                .ConditionalFilter(m => m.Message.ToLower().Contains(searchTerm.ToLower()), !string.IsNullOrEmpty(searchTerm))
                .Paginate(page, size)
                .ToListAsync();

            var count = await Query.CountAsync();

            return (filtered, count);
        }
    }
}
