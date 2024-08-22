using FluentValidation;

namespace SkateShop.Application.Commands.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Email deve estar em um formato válido.")
                .NotEmpty().WithMessage("Propriedade obrigatória: Email");

            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Propriedade obrigatória: CompleteName");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Propriedade obrigatória: Password")
                .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres.")
                .Matches("[0-9]").WithMessage("Senha deve ter pelo menos um número.")
                .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Senha deve ter pelo menos um caracter especial.")
                .Matches("[A-Z]").WithMessage("Senha deve ter pelo menos uma letra maiúscula.");
        }
    }
}
