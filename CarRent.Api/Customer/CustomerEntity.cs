using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.Entities
{
    [Table("customer")]
    public class CustomerEntity
    {
        [Key]
        public long IdCustomer { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string AddressNr { get; set; }
        public int FidPlace { get; set; }

    }
}
