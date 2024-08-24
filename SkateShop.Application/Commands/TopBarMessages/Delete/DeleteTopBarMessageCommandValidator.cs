using FluentValidation;

namespace SkateShop.Application.Commands.TopBarMessages.Delete
{
    public class DeleteTopBarMessageCommandValidator : AbstractValidator<DeleteTopBarMessageCommand>
    {
        public DeleteTopBarMessageCommandValidator() 
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("Propriedade obrigatória: Id");
        }
    }
}
