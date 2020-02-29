using System;

namespace CarRent.Api.EF
{
    public class ReservationReadEntity
    {
        public long IdReservation { get; set; }
        public int Days { get; set; }
        public decimal Price { get; set; }
        public string ReservationNr { get; set; }
        public DateTime PickUpDate { get; set; }
        public Boolean IsLease { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CarName { get; set; }
        public string CarNr { get; set; }
        
    }
}