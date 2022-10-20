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
            var book = await _bookRepository.FindAll();
            return ResultService.Ok<ICollection<Book>>(book);
        }

        public async Task<ResultService<Book>> FindById(int id)
        {
            var book = await _bookRepository.FindById(id);
            if (book == null) return ResultService.Fail<Book>("Book not found");
            return ResultService.Ok(book);
        }

        public async Task<ResultService<Book>> Update(Book book)
        {
            if (book == null) return (ResultService<Book>)ResultService.Fail("Book must be informed");

            var books = await _bookRepository.FindById(book.Id);
            if (books == null) return (ResultService<Book>)ResultService.Fail("Book not found");
            books = _mapper.Map<Book, Book>(book, books);
            var data = await _bookRepository.Update(books);
            return ResultService.Ok(data);
        }
    }
}

