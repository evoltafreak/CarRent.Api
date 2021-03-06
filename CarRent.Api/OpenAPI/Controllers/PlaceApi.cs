/*
 * OpenAPI car rent
 *
 * car rent api
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using OpenAPI.Attributes;
using Microsoft.AspNetCore.Authorization;
using OpenAPI.Models;

namespace OpenAPI.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class PlaceApiController : ControllerBase
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Read all places</remarks>
        /// <response code="200">successful operation</response>
        [HttpGet]
        [Route("/api/place")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(List<Place>))]
        public abstract IActionResult ReadAllPlaces();

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Read place by idPlace</remarks>
        /// <param name="idPlace">The id of the place</param>
        /// <response code="200">successful operation</response>
        [HttpGet]
        [Route("/api/place/{idPlace}")]
        [ValidateModelState]
        [ProducesResponseType(statusCode: 200, type: typeof(Place))]
        public abstract IActionResult ReadPlaceById([FromRoute][Required]long idPlace);
    }
}
