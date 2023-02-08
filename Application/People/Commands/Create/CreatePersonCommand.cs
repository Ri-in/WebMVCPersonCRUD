using Domain;
using MediatR;

namespace Application.People.Commands.Create
{
    public record CreatePersonCommand(string FirstName, string LastName, byte Age)
        : IRequest<Person>;
}
