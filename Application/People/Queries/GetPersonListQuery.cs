using Domain;
using MediatR;

namespace Application.People.Queries
{
    public record GetPersonListQuery() : IRequest<List<Person>>;
}
