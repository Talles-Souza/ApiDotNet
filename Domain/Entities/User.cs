using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        [Column("user_name")]
        public string? UserName { get; set; }
        [Column("full_name")]
        public string? FullName { get; set; }
        [Column("password")]
        public string? Password { get; set; }
        [Column("refresh_token")]
        public string? RefreshToken { get; set; }
        
        [Column("access_token")]
        public string? AccessToken { get; set; }
        
        [Column("refresh_token_expiry_time")]
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public User(string? userName, string? fullName, string password)
        {
            UserName = userName;
            FullName = fullName;
            Password = password;
          
        }
        public User()
        {

        }
    }
}
