namespace SkateShop.Domain
{
    public interface IUnitOfWork
    {
        public Task CommitAsync();
    }
}
