﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.EF;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class PlaceRepository: IPlaceRepository
    {
        
        public MapperConfiguration placeConfig;

        public PlaceRepository()
        {
            placeConfig = new MapperConfiguration(cfg => { cfg.CreateMap<PlaceEntity, Place>(); });
        }

        public List<Place> ReadAllPlaces()
        {
            List<PlaceEntity> placeList = new List<PlaceEntity>();
            using (var context = new CarRentDbContext())
            {
                placeList = context.PlaceEntity.ToList();
            }
            
            IMapper mapper = placeConfig.CreateMapper();
            return mapper.Map<List<PlaceEntity>, List<Place>>(placeList);
        }

        public Place ReadPlaceById(long idPlace)
        {
            PlaceEntity placeEntity = new PlaceEntity();
            using (var context = new CarRentDbContext())
            {
                placeEntity = context.PlaceEntity.Where(c => c.IdPlace == idPlace).FirstOrDefault();
            }
            IMapper mapper = placeConfig.CreateMapper();
            return mapper.Map<PlaceEntity, Place>(placeEntity);
        }


    }
}
