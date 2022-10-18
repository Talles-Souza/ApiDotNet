using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("Last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }

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
