using Application.Interfaces;
using Application.People.Commands;
using Domain;
using MediatR;

namespace Application.People.Handlers
{
    public class DeletePersonHandler
        : IRequestHandler<DeletePersonCommand, Person>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _personRepository.Reade(request.Id).Result;

            _personRepository.Delete(person.Id);
            _personRepository.Save();

            return person;
        }
    }
}
