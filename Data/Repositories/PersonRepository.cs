

using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly MySqlContext _context;

        public PersonRepository(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public async Task<ICollection<Person>> FindAll()
        {
           return await _context.People.ToListAsync();
        }

        public Person FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }

        public Person Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
