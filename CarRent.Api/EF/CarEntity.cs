using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.EF
{
    [Table("car")]
    public class CarEntity
    {
        [Key]
        public long IdCar { get; set; }
        public long FidCarMake { get; set; }
        public string CarName { get; set; }
        public string CarNr { get; set; }
        public long FidCarType { get; set; }
        public long FidCarClass { get; set; }
    }
}
