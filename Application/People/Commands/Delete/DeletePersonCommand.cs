using Domain;
using MediatR;

namespace Application.People.Commands.Delete
{
    public record DeletePersonCommand(int Id)
        : IRequest<Person>;
}
