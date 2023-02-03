using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Person person)
        {
            await _context.People.AddAsync(person);
        }

        public async Task<Person> Reade(int id)
        {
            return await _context.People.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> ReadAll()
        {
            return await _context.People.ToListAsync();
        }

        public void Update(Person person)
        {
            _context.People.Update(person);
        }

        public async void Delete(int id)
        {
            var person = await _context.People.FindAsync(id);
            _context.Remove(person);
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
