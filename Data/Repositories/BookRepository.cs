using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class BookRepository : IBookRepository
    {
        public Task<Book> Create(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Book>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> Update(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
