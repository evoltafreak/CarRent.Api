using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.EF
{
    [Table("carclass")]
    public class CarClassEntity
    {
        [Key]
        public long IdCarClass { get; set; }
        public string CarClass { get; set; }
        public decimal Fee { get; set; }
    }
}
