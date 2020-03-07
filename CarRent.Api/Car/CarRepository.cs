using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.Entities;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class CarRepository: ICarRepository
    {
        
        private MapperConfiguration _carConfig;
        private MapperConfiguration _carConfig2;
        private MapperConfiguration _carTypeConfig;
        private MapperConfiguration _carMakeConfig;
        private MapperConfiguration _carClassConfig;
        private CarRentDbContext dbCtx;

        public CarRepository(CarRentDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
            _carConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarEntity, Car>()
                    .ForPath(dest => dest.CarType.IdCarType, act => act.MapFrom(src => src.FidCarType))
                    .ForPath(dest => dest.CarMake.IdCarMake, act => act.MapFrom(src => src.FidCarMake))
                    .ForPath(dest => dest.CarClass.IdCarClass, act => act.MapFrom(src => src.FidCarClass));
            });
            _carConfig2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarEntity>()
                    .ForPath(dest => dest.FidCarType, act => act.MapFrom(src => src.CarType.IdCarType))
                    .ForPath(dest => dest.FidCarMake, act => act.MapFrom(src => src.CarMake.IdCarMake))
                    .ForPath(dest => dest.FidCarClass, act => act.MapFrom(src => src.CarClass.IdCarClass));
            });
            _carTypeConfig = new MapperConfiguration(cfg => cfg.CreateMap<CarTypeEntity, CarType>());
            _carMakeConfig = new MapperConfiguration(cfg => cfg.CreateMap<CarMakeEntity, CarMake>());
            _carClassConfig = new MapperConfiguration(cfg => cfg.CreateMap<CarClassEntity, CarClass>());
            
            }

        public long AddCar(Car car)
        {
            IMapper mapper = _carConfig2.CreateMapper();
            CarEntity carEntity = mapper.Map<Car, CarEntity>(car);
            dbCtx.CarEntity.Add(carEntity);
            dbCtx.SaveChanges();
            return carEntity.IdCar;
        }

        public int DeleteCarById(long idCar)
        {
            dbCtx.CarEntity.Remove(dbCtx.CarEntity.Single(c => c.IdCar == idCar));
            return dbCtx.SaveChanges();
        }


        public List<Car> ReadAllCars()
        {
            List<CarEntity> carList = new List<CarEntity>();
            carList = dbCtx.CarEntity.ToList();

            IMapper mapper = _carConfig.CreateMapper();
            return mapper.Map<List<CarEntity>, List<Car>>(carList);
        }

        public Car ReadCarById(long idCar)
        {
            CarEntity carEntity = new CarEntity();
            carEntity = dbCtx.CarEntity.Where(c => c.IdCar == idCar).FirstOrDefault();

            IMapper mapper = _carConfig.CreateMapper();
            return mapper.Map<CarEntity, Car>(carEntity);
        }

        public long UpdateCar(Car car)
        {
            IMapper mapper = _carConfig2.CreateMapper();
            CarEntity carEntity = mapper.Map<Car, CarEntity>(car);
            dbCtx.CarEntity.Update(carEntity);
            dbCtx.SaveChanges();
            return carEntity.IdCar;
        }
        
        public CarType ReadCarTypeById(long idCarType)
        {
            CarTypeEntity carTypeEntity = new CarTypeEntity();
            carTypeEntity = dbCtx.CarTypeEntity.Where(c => c.IdCarType == idCarType).FirstOrDefault();
            IMapper mapper = _carTypeConfig.CreateMapper();
            return mapper.Map<CarTypeEntity, CarType>(carTypeEntity);
        }

        public List<CarType> ReadAllCarTypes()
        {
            List<CarTypeEntity> carTypeList = new List<CarTypeEntity>();
            carTypeList = dbCtx.CarTypeEntity.ToList();
            IMapper mapper = _carTypeConfig.CreateMapper();
            return mapper.Map<List<CarTypeEntity>, List<CarType>>(carTypeList);
        }
        
        public CarMake ReadCarMakeById(long idCarMake)
        {
            CarMakeEntity carMakeEntity = new CarMakeEntity();
            carMakeEntity = dbCtx.CarMakeEntity.Where(c => c.IdCarMake == idCarMake).FirstOrDefault();
            IMapper mapper = _carMakeConfig.CreateMapper();
            return mapper.Map<CarMakeEntity, CarMake>(carMakeEntity);
        }

        public List<CarMake> ReadAllCarMakes()
        {
            List<CarMakeEntity> carMakeList = new List<CarMakeEntity>();
            carMakeList = dbCtx.CarMakeEntity.ToList();
            IMapper mapper = _carMakeConfig.CreateMapper();
            return mapper.Map<List<CarMakeEntity>, List<CarMake>>(carMakeList);
        }
        
        public CarClass ReadCarClassById(long idCarClass)
        {
            CarClassEntity carClassEntity = new CarClassEntity();
            carClassEntity = dbCtx.CarClassEntity.Where(c => c.IdCarClass == idCarClass).FirstOrDefault();
            IMapper mapper = _carClassConfig.CreateMapper();
            return mapper.Map<CarClassEntity, CarClass>(carClassEntity);
        }

        public List<CarClass> ReadAllCarClasses()
        {
            List<CarClassEntity> carClassList = new List<CarClassEntity>();
            carClassList = dbCtx.CarClassEntity.ToList();
            IMapper mapper = _carClassConfig.CreateMapper();
            return mapper.Map<List<CarClassEntity>, List<CarClass>>(carClassList);
        }
        
    }
}
