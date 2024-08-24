using Microsoft.EntityFrameworkCore;
using SkateShop.Domain.Entities;
using SkateShop.Domain.Common;
using SkateShop.Infrastructure.Extensions;

namespace SkateShop.Infrastructure.Repositories
{
    public class Repository<TEntity> where TEntity : Entity
    {
        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual IUnitOfWork UnitOfWork => (IUnitOfWork)Context;

        protected DbContext Context { get; private set; }

        protected IQueryable<TEntity> Query => Context.Set<TEntity>();

        public virtual Task<List<TEntity>> GetAllAsync() => Query.ToListAsync();

        public virtual async Task<(List<TEntity> Items, int Count)> GetAllPagedAsync(int page, int size) => 
            (await Query.Paginate(page, size).ToListAsync(), await Query.CountAsync());

        public virtual Task<TEntity?> GetByIdAsync(Guid id) => Query.FirstOrDefaultAsync(x => x.Id == id);

        public void Add(TEntity entity) => Context.Add(entity);

        public void Update(TEntity entity) => Context.Update(entity);

        public void Remove(TEntity entity) => Context.Remove(entity);
    }
}
