using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public interface IReservationRepository
    {
        long AddReservation(Reservation reservation);
        int DeleteReservationById(long idReservation);
        List<Reservation> ReadAllReservation();
        Reservation ReadReservationById(long idReservation);
        long UpdateReservation(Reservation reservation);

    }
}
