using Application.People.Queries;
using Domain;
using MediatR;

namespace Application.People.Handlers
{
    public class GetPersonByIdHandler
        : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IMediator _mediator;

        public GetPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            List<Person> people = await _mediator.Send(new GetPersonListQuery(), cancellationToken);

            Person person = people.FirstOrDefault(p => p.Id == request.Id)!;
            return person;
        }
    }
}
