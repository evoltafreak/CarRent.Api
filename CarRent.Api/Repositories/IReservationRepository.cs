using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public interface IReservationRepository
    {
        long AddReservation(Reservation reservation);
        void DeleteReservationById(long idReservation);
        List<Reservation> ReadAllReservation();
        Reservation ReadReservationById(long idReservation);
        void UpdateReservation(Reservation reservation);

    }
}
