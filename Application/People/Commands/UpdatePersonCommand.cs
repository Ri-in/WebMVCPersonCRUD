using Domain;
using MediatR;

namespace Application.People.Commands
{
    public record UpdatePersonCommand(int Id, string FirstName, string LastName, byte Age)
        : IRequest<Person>;
}
