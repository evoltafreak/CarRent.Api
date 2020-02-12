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
            _reservationService.AddReservation(reservation);
            return StatusCode(200);
        }

        public override IActionResult DeleteReservationById(long idReservation)
        {
            this._reservationService.DeleteReservationById(idReservation);
            return StatusCode(200);
        }

        public override IActionResult ReadAllReservation()
        {
            List<Reservation> reservationList = _reservationService.ReadAllReservation();
            return StatusCode(200, reservationList);
        }

        public override IActionResult ReadReservationById(long idReservation)
        {
            Reservation reservation = _reservationService.ReadReservationById(idReservation);
            return new ObjectResult(reservation);
        }

        public override IActionResult UpdateReservation(Reservation reservation)
        {
            _reservationService.UpdateReservation(reservation);
            return StatusCode(200);
        }
    }
}
