using Domain;
using MediatR;

namespace Application.People.Commands
{
    public record DeletePersonCommand(int Id)
        : IRequest<Person>;
}
