
using Application.DTO;
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
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
            CreateMap<BookDTO, Book>();
            CreateMap<Book, BookDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<RegisterDTO, User>();
            CreateMap<User, RegisterDTO>();
            
           

        }

    }
}
