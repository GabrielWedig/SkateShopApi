using Microsoft.EntityFrameworkCore;
using SkateShop.Domain.Entities;
using SkateShop.Domain.Repositories;

namespace SkateShop.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        } 

        public Task<User?> GetByEmailAsync(string email)
        {
            return Query.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
