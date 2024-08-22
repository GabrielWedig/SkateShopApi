namespace SkateShop.Application.Commands.Users.Login
{
    public class LoginUserCommandResponse
    {
        public LoginUserCommandResponse(
            Guid id,
            string name,
            string token)
        { 
            Id = id;
            Name = name;
            Token = token;
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
