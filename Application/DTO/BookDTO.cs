using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class BookDTO
    {
        public int Id { get; set; } 
        public string Title { get; set; }

     
        public string Author { get; set; }

        
        public decimal Price { get; set; }

      
        public DateTime LaunchDate { get; set; }
    }
}
