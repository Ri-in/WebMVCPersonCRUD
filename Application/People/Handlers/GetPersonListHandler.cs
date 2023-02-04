using Application.Interfaces;
using Application.People.Queries;
using Domain;
using MediatR;

namespace Application.People.Handlers
{
    public class GetPersonListHandler
        : IRequestHandler<GetPersonListQuery, List<Person>>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonListHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_personRepository.ReadAll().Result.ToList());
        }
    }
}
