using MediatR;

namespace Application.People.Commands
{
    public record CreatePersonCommand(string FirstName, string LastName, byte Age)
        : IRequest<int>;
}
