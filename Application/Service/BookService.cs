using Application.Service.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;

namespace Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<Book>> Create(Book book)
        {

            if (book == null) return ResultService.Fail<Book>("Object must be informed");
            var data = await _bookRepository.Create(book);
            return ResultService.Ok(data);
        }

        public async Task<ResultService> Delete(int id)
        {
            var book = await _bookRepository.FindById(id);
            if (book == null) return ResultService.Fail<Book>("Book not found");
            await _bookRepository.Delete(id);
            return ResultService.Ok("Book with the id : " + id + " was successfully deleted");
        }

        public async Task<ResultService<ICollection<Book>>> FindAll()
        {
            var people = await _personRepository.FindAll();
            return ResultService.Ok<ICollection<Person>>(people);
        }

        public async Task<ResultService<Book>> FindById(int id)
        {
            var person = await _personRepository.FindById(id);
            if (person == null) return ResultService.Fail<Person>("Person not found");
            return ResultService.Ok(person);
        }

        public async Task<ResultService<Book>> Update(Book book)
        {
            if (person == null) return (ResultService<Person>)ResultService.Fail("Person must be informed");

            var persons = await _personRepository.FindById(person.Id);
            if (persons == null) return (ResultService<Person>)ResultService.Fail("Person not found");
            persons = _mapper.Map<Person, Person>(person, persons);
            var data = await _personRepository.Update(persons);
            return ResultService.Ok(data);
        }
    }
}

