using CarRent.Api.Repositories;
using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public class CarService: ICarService
    {

        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            this._carRepository = carRepository;
        }

        public long AddCar(Car car)
        {
            return _carRepository.AddCar(car);
        }

        public void DeleteCarById(long idCar)
        {
            _carRepository.DeleteCarById(idCar);
        }


        public List<Car> ReadAllCars()
        {
            List<Car> carList = _carRepository.ReadAllCars();
            foreach (Car car in carList)
            {
                car.CarType = _carRepository.ReadCarTypeById(car.CarType.IdCarType);
                car.CarMake = _carRepository.ReadCarMakeById(car.CarMake.IdCarMake);
                car.CarClass = _carRepository.ReadCarClassById(car.CarClass.IdCarClass);
            }

            return carList;
        }

        public Car ReadCarById(long idCar)
        {
            Car car = _carRepository.ReadCarById(idCar);
            car.CarType = _carRepository.ReadCarTypeById(car.CarType.IdCarType);
            car.CarMake = _carRepository.ReadCarMakeById(car.CarMake.IdCarMake);
            car.CarClass = _carRepository.ReadCarClassById(car.CarClass.IdCarClass);
            return car;
        }

        public void UpdateCar(Car car)
        {
            _carRepository.UpdateCar(car);
        }

        public List<CarType> ReadAllCarTypes()
        {
            return _carRepository.ReadAllCarTypes();
        }

        public List<CarMake> ReadAllCarMakes()
        {
            return _carRepository.ReadAllCarMakes();
        }
        
        public List<CarClass> ReadAllCarClasses()
        {
            return _carRepository.ReadAllCarClasses();
        }
        
    }
}
