

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

        public async Task<Person> Create(Person person)
        {
            try
            {
                _context.Add(person);
                await _context.SaveChangesAsync();  

            }
            catch (Exception)
            {

                throw;
            }
           return person;
        }

        public Task<Person> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Person>> FindAll()
        {
           return await _context.People.ToListAsync();
        }

        public Task<Person> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
