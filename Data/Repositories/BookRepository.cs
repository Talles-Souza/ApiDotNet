using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MySqlContext _context;

        public BookRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            try
            {
                _context.Add(book);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Book book = await _context.Books.Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();
                if (book == null) return false;
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ICollection<Book>> FindAll()
        {
            List<Book> book = await _context.Books.ToListAsync();
            return book;
        }

        public async Task<Book> FindById(int id)
        {
            Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }

        public async Task<Book> Update(Book book)
        {
            _context.Update(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
