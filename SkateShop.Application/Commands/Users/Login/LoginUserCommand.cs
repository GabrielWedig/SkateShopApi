using MediatR;

namespace SkateShop.Application.Commands.Users.Login
{
    public class LoginUserCommand : IRequest<LoginUserCommandResponse?>
    {
        public LoginUserCommand(
            string email, 
            string password) 
        { 
            Email = email;
            Password = password;
        }

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
