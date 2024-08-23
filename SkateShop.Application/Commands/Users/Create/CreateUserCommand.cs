using MediatR;
using SkateShop.Application.Commands.Users.Login;

namespace SkateShop.Application.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<LoginUserCommandResponse?>
    {
        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
