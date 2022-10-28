using Application.DTO;
using Application.Service.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class RegisterService : IRegisterService
    {
        private IUserRepository userRepository;
        private readonly IMapper _mapper;

        public RegisterService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            _mapper = mapper;
        }

        public  string Create(RegisterDTO registerDTO)
        {
            //var user=  _mapper.Map<User>(registerDTO);
            User user = new User();
            user.UserName = registerDTO.UserName;   
            user.FullName = registerDTO.FullName;
            user.Password = registerDTO.Password;
            userRepository.Create(user);
            return "User created";
        }
    }
}
