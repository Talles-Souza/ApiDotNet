using Domain.Entities;

namespace Application.Service.Interface
{
    public interface IBookService
    {
        Task<ResultService<Book>> Create(Book book);
        Task<ResultService<ICollection<Book>>> FindAll();
        Task<ResultService<Book>> FindById(int id);
        Task<ResultService<Book>> Update(Book book);
        Task<ResultService> Delete(int id);
    }
}
