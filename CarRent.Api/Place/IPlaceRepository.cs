using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public interface IPlaceRepository
    {
        List<Place> ReadAllPlaces();
        Place ReadPlaceById(long idPlace);
    }
}
