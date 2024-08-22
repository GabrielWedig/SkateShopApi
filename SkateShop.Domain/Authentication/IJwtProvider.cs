using SkateShop.Domain.Entities;

namespace SkateShop.Domain.Authentication
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
