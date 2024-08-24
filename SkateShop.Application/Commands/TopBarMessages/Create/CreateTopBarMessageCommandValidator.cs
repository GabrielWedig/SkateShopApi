using FluentValidation;

namespace SkateShop.Application.Commands.TopBarMessages.Create
{
    public class CreateTopBarMessageCommandValidator : AbstractValidator<CreateTopBarMessageCommand>
    {
        public CreateTopBarMessageCommandValidator() 
        {
            RuleFor(m => m.Message)
                .NotEmpty().WithMessage("Propriedade obrigatória: Message");
        }
    }
}
