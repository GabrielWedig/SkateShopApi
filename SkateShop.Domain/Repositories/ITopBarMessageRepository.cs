﻿using SkateShop.Domain.Entities;

namespace SkateShop.Domain.Repositories
{
    public interface ITopBarMessageRepository : IRepository<TopBarMessage>
    {
        Task<(List<TopBarMessage> Items, int Total)> GetAllFilteredPagedAsync(string searchTerm, int page, int size);
    }
}
