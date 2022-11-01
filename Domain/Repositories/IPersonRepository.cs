using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> Create (Person person);
        Task<ICollection<Person>> FindAll();
        Task<Person> FindById (int id);
        Task<Person> Update (Person person);
        Person Disable(int id); 
        List<Person> FindByName(string firstName );
        Task<bool> Delete(int id);

    }
}
