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

        public async Task<ResultService<ICollection<Person>>> FindAll()
        {
            var people = await _personRepository.FindAll();
            return ResultService.Ok<ICollection<Person>>(people);
        }

        public async Task<ResultService<Person>> FindById(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person == null) return ResultService.Fail<Person>("Person not found");
            return ResultService.Ok(person);
        }

        public async Task<ResultService<Person>> Update(Person person)
        {
            if (person == null) return (ResultService<Person>)ResultService.Fail("Person must be informed");
            
            var person1 = await _personRepository.FindById(person.Id);
            if (person1 == null) return (ResultService<Person>)ResultService.Fail("Person not found");
            var data = await _personRepository.Update(person);
            return ResultService.Ok(data);
        }
        public async Task<ResultService<Person>> Create(Person person)
        {
            if (person == null) return ResultService.Fail<Person>("Object must be informed");
            var data = await _personRepository.Create(person);
            return ResultService.Ok(data);
        }

        public async Task<ResultService> Delete(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person == null) return ResultService.Fail<Person>("Person not found");
            await _personRepository.Delete(id);
            return ResultService.Ok("Person with the id : " + id + " was successfully deleted");
        }


    }
}
