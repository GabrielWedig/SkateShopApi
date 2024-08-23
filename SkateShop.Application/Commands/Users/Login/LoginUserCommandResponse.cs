namespace SkateShop.Application.Commands.Users.Login
{
    public class LoginUserCommandResponse
    {
        public LoginUserCommandResponse(string token)
        { 
            Token = token;
        }

        public string Token { get; set; } = string.Empty;
    }
}
