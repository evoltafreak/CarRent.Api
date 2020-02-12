using OpenAPI.Models;
using System.Collections.Generic;

namespace CarRent.Api.Services
{
    public class ReservationService: IReservationService
    {

        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }

        public void AddReservation(Reservation reservation)
        {
            _reservationRepository.AddReservation(reservation);
        }

        public void DeleteReservationById(long idReservation)
        {
            _reservationRepository.DeleteReservationById(idReservation);
        }

        public List<Reservation> ReadAllReservation()
        {
            return _reservationRepository.ReadAllReservation();
        }

        public Reservation ReadReservationById(long idReservation)
        {
            return _reservationRepository.ReadReservationById(idReservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.UpdateReservation(reservation);
        }
    }
}
