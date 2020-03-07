using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.Entities
{
    [Table("cartype")]
    public class CarTypeEntity
    {
        [Key]
        public long IdCarType { get; set; }
        public string CarType { get; set; }
    }
}
