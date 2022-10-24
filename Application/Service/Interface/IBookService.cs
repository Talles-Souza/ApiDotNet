using Application.DTO;
using Domain.Entities;

namespace Application.Service.Interface
{
    public interface IBookService
    {
        Task<ResultService<BookDTO>> Create(BookDTO bookDTO);
        Task<ResultService<ICollection<BookDTO>>> FindAll();
        Task<ResultService<BookDTO>> FindById(int id);
        Task<ResultService<BookDTO>> Update(BookDTO bookDTO);
        Task<ResultService> Delete(int id);
    }
}
