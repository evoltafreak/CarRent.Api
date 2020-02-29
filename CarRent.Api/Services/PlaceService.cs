using CarRent.Api.Repositories;
using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public class PlaceService: IPlaceService
    {
        
        private readonly IPlaceRepository _placeRepository;

        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        
        public List<Place> ReadAllPlaces()
        {
            return _placeRepository.ReadAllPlaces();
        }

        public Place ReadPlaceById(long idPlace)
        {
            return _placeRepository.ReadPlaceById(idPlace);
        }

    }
}
