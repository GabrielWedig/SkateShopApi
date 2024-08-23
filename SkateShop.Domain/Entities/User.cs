namespace SkateShop.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;

        public List<Permission> Permissions { get; set; } = new List<Permission>();

        public void WithPermissions()
        {
            Permissions = new List<Permission> { };
        }

        public User() { }

        public User(
            string name,
            string email,
            string password)
        { 
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
