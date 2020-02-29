using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Api.EF
{
    [Table(("reservation"))]
    public class ReservationEntity
    {
        [Key]
        public long IdReservation { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
        public string ReservationNr { get; set; }
        public DateTime PickUpDate { get; set; }
        public int IsLease { get; set; }
        public long FidCustomer { get; set; }
        public long FidCar { get; set; }

    }
}
