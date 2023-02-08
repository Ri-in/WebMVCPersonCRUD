using FluentValidation;

namespace Application.People.Commands.Delete
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
