using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.EF
{
    [Table("carmake")]
    public class CarMakeEntity
    {
        [Key]
        public long IdCarMake { get; set; }
        public string CarMake { get; set; }
    }
}
