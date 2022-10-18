using Application.Service.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<Person> Create(Person person)
        {
         //depois vou criiar a validação de dados
         return _personRepository.Create(person); 
            
        }

        public async Task<ICollection<Person>> FindAll()
        {
            return await _personRepository.FindAll();
        }
    }
}
