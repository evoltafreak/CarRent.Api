using OpenAPI.Models;
using System.Collections.Generic;
using CarRent.Api.Repositories;

namespace CarRent.Api.Services
{
    public class ReservationService: IReservationService
    {

        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;

        public ReservationService(IReservationRepository reservationRepository,
            ICustomerRepository customerRepository,
            ICarRepository carRepository)
        {
            _reservationRepository = reservationRepository;
            _customerRepository = customerRepository;
            _carRepository = carRepository;
        }

        public long AddReservation(Reservation reservation)
        {
            return _reservationRepository.AddReservation(reservation);
        }

        public void DeleteReservationById(long idReservation)
        {
            _reservationRepository.DeleteReservationById(idReservation);
        }

        public List<Reservation> ReadAllReservation()
        {
            List<Reservation> reservationList = _reservationRepository.ReadAllReservation();
            foreach(Reservation reservation in reservationList)
            {
                reservation.Customer = _customerRepository.ReadCustomerById(reservation.Customer.IdCustomer);
                reservation.Car = _carRepository.ReadCarById(reservation.Car.IdCar);
            }

            return reservationList;
        }

        public Reservation ReadReservationById(long idReservation)
        {
            Reservation reservation = _reservationRepository.ReadReservationById(idReservation);
            reservation.Customer = _customerRepository.ReadCustomerById(reservation.Customer.IdCustomer);
            reservation.Car = _carRepository.ReadCarById(reservation.Car.IdCar);
            return reservation;
        }

        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.UpdateReservation(reservation);
        }
    }
}
