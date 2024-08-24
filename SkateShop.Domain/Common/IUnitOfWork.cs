namespace SkateShop.Domain.Common
{
    public interface IUnitOfWork
    {
        public Task CommitAsync();
    }
}
