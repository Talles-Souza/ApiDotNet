using Application.DTO;
using Application.Service.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Generic;
using System;

namespace Application.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<BookDTO>> Create(BookDTO bookDTO)
        {

            if (bookDTO == null) return ResultService.Fail<BookDTO>("Object must be informed");
            var data = await _bookRepository.Create(_mapper.Map<Book>(bookDTO));
            return ResultService.Ok(_mapper.Map<BookDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
            var book = await _bookRepository.FindById(id);
            if (book == null) return ResultService.Fail<Book>("Book not found");
            await _bookRepository.Delete(id);
            return ResultService.Ok("Book with the id : " + id + " was successfully deleted");
        }

        public async Task<ResultService<ICollection<BookDTO>>> FindAll()
        {
            var book = await _bookRepository.FindAll();
            return ResultService.Ok<ICollection<BookDTO>>(_mapper.Map<ICollection<BookDTO>>(book));
        }

        public async Task<ResultService<BookDTO>> FindById(int id)
        {
            var book = await _bookRepository.FindById(id);
            if (book == null) return ResultService.Fail<BookDTO>("Book not found");
            return ResultService.Ok(_mapper.Map<BookDTO>(book));
        }

        public async Task<ResultService<BookDTO>> Update(BookDTO bookDTO)
        {
            if (bookDTO == null) return (ResultService<BookDTO>)ResultService.Fail("Book must be informed");
          
            var  books = await _bookRepository.FindById(bookDTO.Id);
            if (books == null) return (ResultService<BookDTO>)ResultService.Fail("Book not found");
            books = _mapper.Map<BookDTO, Book>(bookDTO, books);
            var data = await _bookRepository.Update(books);
            return ResultService.Ok(_mapper.Map<BookDTO>(data));
        }
    }
}

