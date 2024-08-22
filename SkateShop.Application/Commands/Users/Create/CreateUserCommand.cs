using MediatR;
using SkateShop.Domain;

namespace SkateShop.Application.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<Nothing>
    {
        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
