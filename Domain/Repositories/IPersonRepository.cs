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
        Person Create (Person person);
        List<Person> FindAll();
        Person FindById (int id);
        Person Update (Person person);
        Person Delete (int id);
    }
}
