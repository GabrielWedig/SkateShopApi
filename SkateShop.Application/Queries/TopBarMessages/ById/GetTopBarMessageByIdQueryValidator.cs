using FluentValidation;

namespace SkateShop.Application.Queries.TopBarMessages.ById
{
    public class GetTopBarMessageByIdQueryValidator : AbstractValidator<GetTopBarMessageByIdQuery>
    {
        public GetTopBarMessageByIdQueryValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("Propriedade obrigatória: Id");
        }
    }
}
