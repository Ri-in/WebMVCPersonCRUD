using FluentValidation;

namespace Application.People.Commands.Update
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MaximumLength(25)
                .MinimumLength(2);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MaximumLength(25)
                .MinimumLength(2);

            RuleFor(p => p.Age)
                .NotEmpty()
                .Must(BeValidAge);
        }

        private bool BeValidAge(byte age)
        {
            if (age < 18 || age > 100)
            {
                return false;
            }

            return true;
        }
    }
}
