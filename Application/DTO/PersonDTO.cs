using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Hypermedia.Abstract;
using Application.Hypermedia;

namespace Application.DTO
{
    public class PersonDTO : ISupportHyperMedia
    {
     
        public int Id { get; set; }
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
       
        public string Address { get; set; }
      
        public string Gender { get; set; }
        public bool Enabled { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();   
    }
}

