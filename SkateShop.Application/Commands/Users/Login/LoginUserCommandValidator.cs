using FluentValidation;

namespace SkateShop.Application.Commands.Users.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty().WithMessage("Propriedade obrigatória: Name");

            RuleFor(l => l.Password)
                .NotEmpty().WithMessage("Propriedade obrigatória: Password"); ;
        }
    }
}
