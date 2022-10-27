using Data.Context;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepository(MySqlContext context)
        {
            _context = context;
        }

        public  User ValidateCredentials(User user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return  _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public async Task<User> RefreshUserInfo(User user)
        {
            if (!await _context.Users.AnyAsync(u => u.Id.Equals(user.Id))) return null;
            var result = await _context.Users.SingleOrDefaultAsync(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
              return result;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algoriti)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algoriti.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public  User Create(User user)

        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            user.Password = pass;
            _context.Add(user);
            _context.SaveChanges();
            return user;

        }
    }
}
