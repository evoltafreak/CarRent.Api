using CarRent.Api.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Controllers;
using OpenAPI.Models;
using System.Collections.Generic;

namespace CarRent.Api.Controllers
{

    public class PlaceApiCtrl : PlaceApiController
    {

        private readonly IPlaceService _placeService;

        public PlaceApiCtrl(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        public override IActionResult ReadAllPlaces()
        {
            List<Place> placeList = _placeService.ReadAllPlaces();
            return StatusCode(200, placeList);
        }

        public override IActionResult ReadPlaceById(long idPlace)
        {
            Place place = _placeService.ReadPlaceById(idPlace);
            return new ObjectResult(place);
        }

    }
}
