using CarRent.Api.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Controllers;
using OpenAPI.Models;
using System.Collections.Generic;

namespace CarRent.Api.Controllers
{

    public class ReservationApiCtrl : ReservationApiController
    {

        private readonly IReservationService _reservationService;

        public ReservationApiCtrl(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public override IActionResult AddReservation(Reservation reservation)
        {
            long idReservation = _reservationService.AddReservation(reservation);
            return StatusCode(200, idReservation);
        }

        public override IActionResult DeleteReservationById(long idReservation)
        {
            int deleted = _reservationService.DeleteReservationById(idReservation);
            return StatusCode(200, deleted);
        }

        public override IActionResult ReadAllReservation()
        {
            List<Reservation> reservationList = _reservationService.ReadAllReservation();
            return StatusCode(200, reservationList);
        }

        public override IActionResult ReadReservationById(long idReservation)
        {
            Reservation reservation = _reservationService.ReadReservationById(idReservation);
            return reservation == null ? StatusCode(404, reservation) : StatusCode(200, reservation);
        }

        public override IActionResult UpdateReservation(Reservation reservation)
        {
            long idReservation = _reservationService.UpdateReservation(reservation);
            return StatusCode(200, idReservation);
        }
    }
}
