using FluentValidation;

namespace Application.People.Queries
{
    public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
