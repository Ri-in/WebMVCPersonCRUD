using FluentValidation;

namespace Application.People.Commands.Create
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("*First name is required!")
                .Length(2, 25).WithMessage("*The length of the first name must be at least 2 and no more than 25 characters!");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("*First name is required!")
                .Length(2, 25).WithMessage("*The length of the first name must be at least 2 and no more than 25 characters!");

            RuleFor(p => (int)p.Age)
                .NotEmpty().WithMessage("*Age is required!")
                .InclusiveBetween(18, 100).WithMessage("*The age must be at least 18 and not more than 100 years!");
        }
    }
}
