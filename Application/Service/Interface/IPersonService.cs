using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IPersonService
    {
        Task<ResultService<Person>> Create(Person personDTO);
        Task<ResultService<ICollection<Person>>> FindAll();
        Task<ResultService<Person>> FindById(int id);
        Task<ResultService<Person>> Update(Person personDTO);
        Task<ResultService> Delete(int id);
    }
}
