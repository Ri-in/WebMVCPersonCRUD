using Domain;

namespace Application.Interfaces
{
    public interface IPersonRepository
    {
        Task Create(Person person);
        Task<Person> Reade(int id);
        Task<IEnumerable<Person>> ReadAll();
        void Update (Person person);
        void Delete(int id);

        void Save();
    }
}
