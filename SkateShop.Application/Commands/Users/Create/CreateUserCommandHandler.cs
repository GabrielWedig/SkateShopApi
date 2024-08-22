using SkateShop.Domain.Entities;
using SkateShop.Domain;
using SkateShop.Domain.Authentication;
using SkateShop.Domain.Notifications;
using SkateShop.Domain.Repositories;
using MediatR;

namespace SkateShop.Application.Commands.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Nothing>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly INotificationContext _notification;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            INotificationContext notification)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _notification = notification;
        }

        public async Task<Nothing> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user != null)
            {
                _notification.AddBadRequest("Email já registrado.");
                return default;
            }

            var hashedPassword = _passwordHasher.Generate(command.Password);

            var newUser = new User(
                command.Name,
                command.Email,
                hashedPassword);

            newUser.WithPermissions();

            _userRepository.Add(newUser);
            await _userRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
