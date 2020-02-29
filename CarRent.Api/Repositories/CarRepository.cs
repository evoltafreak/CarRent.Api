using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.EF;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class CarRepository: ICarRepository
    {
        
        public MapperConfiguration carConfig;
        public MapperConfiguration carConfig2;
        public MapperConfiguration carTypeConfig;
        public MapperConfiguration carMakeConfig;
        public MapperConfiguration carClassConfig;

        public CarRepository()
        {
            carConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarEntity, Car>()
                    .ForPath(dest => dest.CarType.IdCarType, act => act.MapFrom(src => src.FidCarType))
                    .ForPath(dest => dest.CarMake.IdCarMake, act => act.MapFrom(src => src.FidCarMake))
                    .ForPath(dest => dest.CarClass.IdCarClass, act => act.MapFrom(src => src.FidCarClass));
            });
            carConfig2 = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarEntity>()
                    .ForPath(dest => dest.FidCarType, act => act.MapFrom(src => src.CarType.IdCarType))
                    .ForPath(dest => dest.FidCarMake, act => act.MapFrom(src => src.CarMake.IdCarMake))
                    .ForPath(dest => dest.FidCarClass, act => act.MapFrom(src => src.CarClass.IdCarClass));
            });
            carTypeConfig = new MapperConfiguration(cfg => cfg.CreateMap<CarTypeEntity, CarType>());
            carMakeConfig = new MapperConfiguration(cfg => cfg.CreateMap<CarMakeEntity, CarMake>());
            carClassConfig = new MapperConfiguration(cfg => cfg.CreateMap<CarClassEntity, CarClass>());
            
            }

        public long AddCar(Car car)
        {
            IMapper mapper = carConfig2.CreateMapper();
            CarEntity carEntity = new CarEntity();
            using (var context = new CarRentDbContext())
            {
                carEntity = mapper.Map<Car, CarEntity>(car);
                context.CarEntity.Add(carEntity);
                context.SaveChanges();
            }
            return carEntity.IdCar;
        }

        public void DeleteCarById(long idCar)
        {
            using (var context = new CarRentDbContext())
            {
                context.CarEntity.Remove(context.CarEntity.Single(c => c.IdCar == idCar));
                context.SaveChanges();
            }
        }


        public List<Car> ReadAllCars()
        {
            List<CarEntity> carList = new List<CarEntity>();
            using (var context = new CarRentDbContext())
            {
                carList = context.CarEntity.ToList();
            }
            
            IMapper mapper = carConfig.CreateMapper();
            return mapper.Map<List<CarEntity>, List<Car>>(carList);
        }

        public Car ReadCarById(long idCar)
        {
            CarEntity carEntity = new CarEntity();
            using (var context = new CarRentDbContext())
            {
                carEntity = context.CarEntity.Where(c => c.IdCar == idCar).FirstOrDefault();
            }
            IMapper mapper = carConfig.CreateMapper();
            return mapper.Map<CarEntity, Car>(carEntity);
        }

        public void UpdateCar(Car car)
        {
            IMapper mapper = carConfig2.CreateMapper();
            using (var context = new CarRentDbContext())
            {
                context.CarEntity.Update(mapper.Map<Car, CarEntity>(car));
                context.SaveChanges();
            }
        }
        
        public CarType ReadCarTypeById(long idCarType)
        {
            CarTypeEntity carTypeEntity = new CarTypeEntity();
            using (var context = new CarRentDbContext())
            {
                carTypeEntity = context.CarTypeEntity.Where(c => c.IdCarType == idCarType).FirstOrDefault();
            }
            IMapper mapper = carTypeConfig.CreateMapper();
            return mapper.Map<CarTypeEntity, CarType>(carTypeEntity);
        }

        public List<CarType> ReadAllCarTypes()
        {
            List<CarTypeEntity> carTypeList = new List<CarTypeEntity>();
            using (var context = new CarRentDbContext())
            {
                carTypeList = context.CarTypeEntity.ToList();
            }
            IMapper mapper = carTypeConfig.CreateMapper();
            return mapper.Map<List<CarTypeEntity>, List<CarType>>(carTypeList);
        }
        
        public CarMake ReadCarMakeById(long idCarMake)
        {
            CarMakeEntity carMakeEntity = new CarMakeEntity();
            using (var context = new CarRentDbContext())
            {
                carMakeEntity = context.CarMakeEntity.Where(c => c.IdCarMake == idCarMake).FirstOrDefault();
            }
            IMapper mapper = carMakeConfig.CreateMapper();
            return mapper.Map<CarMakeEntity, CarMake>(carMakeEntity);
        }

        public List<CarMake> ReadAllCarMakes()
        {
            List<CarMakeEntity> carMakeList = new List<CarMakeEntity>();
            using (var context = new CarRentDbContext())
            {
                carMakeList = context.CarMakeEntity.ToList();
            }
            IMapper mapper = carMakeConfig.CreateMapper();
            return mapper.Map<List<CarMakeEntity>, List<CarMake>>(carMakeList);
        }
        
        public CarClass ReadCarClassById(long idCarClass)
        {
            CarClassEntity carClassEntity = new CarClassEntity();
            using (var context = new CarRentDbContext())
            {
                carClassEntity = context.CarClassEntity.Where(c => c.IdCarClass == idCarClass).FirstOrDefault();
            }
            IMapper mapper = carClassConfig.CreateMapper();
            return mapper.Map<CarClassEntity, CarClass>(carClassEntity);
        }

        public List<CarClass> ReadAllCarClasses()
        {
            List<CarClassEntity> carClassList = new List<CarClassEntity>();
            using (var context = new CarRentDbContext())
            {
                carClassList = context.CarClassEntity.ToList();
            }
            IMapper mapper = carClassConfig.CreateMapper();
            return mapper.Map<List<CarClassEntity>, List<CarClass>>(carClassList);
        }
        
    }
}
