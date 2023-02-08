using Application.Interfaces;
using Application.People.Commands.Update;
using Domain;
using MediatR;

namespace Application.People.Handlers
{
    public class UpdatePersonHandler
        : IRequestHandler<UpdatePersonCommand, Person>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = _personRepository.Reade(request.Id).Result;

            person.FirstName = request.FirstName;
            person.LastName = request.LastName;
            person.Age = request.Age;

            _personRepository.Update(person);
            _personRepository.Save();

            return person;
        }
    }
}
