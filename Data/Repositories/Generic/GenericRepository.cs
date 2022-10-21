using Domain.Base;
using Domain.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Generic
{
    internal class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task<T> Create(T item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
