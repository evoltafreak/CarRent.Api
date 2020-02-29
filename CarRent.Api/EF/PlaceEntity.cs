using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.EF
{
    [Table("place")]
    public class PlaceEntity
    {
        [Key]
        public int IdPlace { get; set; }
        public string ZipCode { get; set; }
        public string Place { get; set; }
        public string Canton { get; set; }
        public string CantonAbb { get; set; }
    }
}
