using Application.DTO;
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
        Task<ResultService<PersonDTO>> Create(PersonDTO personDTO);
        Task<ResultService<ICollection<PersonDTO>>> FindAll();
        List<PersonDTO> FindByName(string firstName);  
        Task<ResultService<PersonDTO>> FindById(int id);
        Task<ResultService<PersonDTO>> Update(PersonDTO personDTO);
        PersonDTO Disable (int id);
        Task<ResultService> Delete(int id);
    }
}
