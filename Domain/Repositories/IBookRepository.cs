using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book);
        Task<ICollection<Book>> FindAll();
        Task<Book> FindById(int id);
        Task<Book> Update(Book book);
        Task<bool> Delete(int id);
    }
}
