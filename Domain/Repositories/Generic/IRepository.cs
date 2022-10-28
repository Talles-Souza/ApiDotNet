
using Domain.Base;
using Domain.Entities;


namespace Domain.Repositories.Generic
{

    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Create(T item);
        Task<ICollection<T>> FindAll();
        Task<T> FindById(int id);
        Task<T> Update(T item);
        Task<bool> Delete(int id);
    }
}
