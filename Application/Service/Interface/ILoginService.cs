using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface ILoginService
    {
        TokenDTO ValidateCredentials(UserDTO userDTO); 
        TokenDTO ValidateCredentials(AccessDTO token);
        bool RevokeToken(string userName);
    }
}
