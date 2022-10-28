using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        User ValidateCredentials (User user);
        User ValidateCredentials (string userName);
        User RefreshUserInfo(User user);
        User Create(User user);
    }
}
