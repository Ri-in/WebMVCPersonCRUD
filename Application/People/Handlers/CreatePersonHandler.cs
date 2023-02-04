using Application.Interfaces;
using Application.People.Commands;
using Domain;
using MediatR;

namespace Application.People.Handlers
{
    public class CreatePersonHandler
        : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            Person person = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age
            };

            await _personRepository.Create(person);
            _personRepository.Save();

            return person.Id;
        }
    }
}
