
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, Person>();
            CreateMap<Book, Book>();
           
           
        }
    }
}
