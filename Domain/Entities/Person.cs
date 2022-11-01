using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("person")]
    public class Person : BaseEntity
    {
        [Column("first_name")]
        [Required]
        [StringLength(150)]
        public string? FirstName { get; set; }
        [Column("Last_name")]
        //[Required]
        [StringLength(150)]
        public string? LastName { get; set; }
        [Column("address")]
        //[Required]
        [StringLength(150)]
        public string Address { get; set; }
        [Column("gender")]
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }

     

        public Person(int id, string firstName, string lastName, string address, string gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Gender = gender;
        }
        public Person()
        {

        }
    }
}
