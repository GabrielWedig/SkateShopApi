using SkateShop.Domain.Entities;
using SkateShop.Domain.Authentication;
using SkateShop.Domain.Notifications;
using SkateShop.Domain.Repositories;
using MediatR;
using SkateShop.Application.Commands.Users.Login;

namespace SkateShop.Application.Commands.Users.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, LoginUserCommandResponse?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly INotificationContext _notification;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            INotificationContext notification,
            IMediator mediator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _notification = notification;
            _mediator = mediator;
        }

        public async Task<LoginUserCommandResponse?> Handle(CreateUserCommand command, CancellationToken cancellationToken)
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

            var loginCommand = new LoginUserCommand(command.Email, command.Password);

            return await _mediator.Send(loginCommand);
        }
    }
}
