namespace SkateShop.Domain.Entities
{
    public class Permission : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; } = new User();

        public string Name { get; set; } = string.Empty;

        public Permission() { }
    }
}
