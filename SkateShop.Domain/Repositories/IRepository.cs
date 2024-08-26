using SkateShop.Domain.Common;
using SkateShop.Domain.Entities;

namespace SkateShop.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(Guid id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
