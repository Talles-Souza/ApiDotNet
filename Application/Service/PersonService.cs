using Application.DTO;
using Application.Service.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ICollection<PersonDTO>>> FindAll()
        {
            var people = await _personRepository.FindAll();
            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> FindById(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person == null) return ResultService.Fail<PersonDTO>("Person not found");
            return ResultService.Ok(_mapper.Map< PersonDTO>(person));
        }

        public async Task<ResultService<PersonDTO>> Update(PersonDTO personDTO)
        {
            if (personDTO == null) return (ResultService<PersonDTO>)ResultService.Fail("Person must be informed");
            
           var persons = await _personRepository.FindById(personDTO.Id);
            if (persons == null) return (ResultService<PersonDTO>)ResultService.Fail("Person not found");
            persons = _mapper.Map<PersonDTO, Person>(personDTO, persons);
            var data = await _personRepository.Update(persons);
            return ResultService.Ok(_mapper.Map<PersonDTO>(data));
        }
        public List<PersonDTO> FindByName(string firstName)
        {
            return _mapper.Map<List<PersonDTO>>(_personRepository.FindByName(firstName));
        }
        public async Task<ResultService<PersonDTO>> Create(PersonDTO personDTO)
        {
            if (personDTO == null) return ResultService.Fail<PersonDTO>("Object must be informed");
            var persons = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.Create(persons);
            return ResultService.Ok(_mapper.Map<PersonDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person == null) return ResultService.Fail<Person>("Person not found");
            await _personRepository.Delete(id);
            return ResultService.Ok("Person with the id : " + id + " was successfully deleted");
        }

        public PersonDTO Disable(int id)
        {
            var personEntity = _personRepository.Disable(id);
            return _mapper.Map<PersonDTO>(personEntity);
        }

        
    }
}
