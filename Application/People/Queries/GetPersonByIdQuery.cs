using Domain;
using MediatR;

namespace Application.People.Queries
{
    public record GetPersonByIdQuery(int Id)
        : IRequest<Person>;
}
