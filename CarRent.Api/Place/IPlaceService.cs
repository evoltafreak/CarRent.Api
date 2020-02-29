using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public interface IPlaceService
    {
        List<Place> ReadAllPlaces();
        Place ReadPlaceById(long idPlace);

    }
}
