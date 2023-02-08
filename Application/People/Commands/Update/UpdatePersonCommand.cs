using Domain;
using MediatR;

namespace Application.People.Commands.Update
{
    public record UpdatePersonCommand(int Id, string FirstName, string LastName, byte Age)
        : IRequest<Person>;
}
