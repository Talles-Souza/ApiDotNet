using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
