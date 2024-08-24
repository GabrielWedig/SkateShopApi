using FluentValidation;

namespace SkateShop.Application.Commands.TopBarMessages.Update
{
    public class UpdateTopBarMessageCommandValidator : AbstractValidator<UpdateTopBarMessageCommand>
    {
        public UpdateTopBarMessageCommandValidator() 
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("Propriedade obrigatória: Id");
        }
    }
}
