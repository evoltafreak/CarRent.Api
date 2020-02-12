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

        public void AddCar(Car car)
        {
            _carRepository.AddCar(car);
        }

        public void DeleteCarById(long idCar)
        {
            _carRepository.DeleteCarById(idCar);
        }


        public List<Car> ReadAllCars()
        {
            return _carRepository.ReadAllCars();
        }

        public Car ReadCarById(long idCar)
        {
            return _carRepository.ReadCarById(idCar);
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
    }
}
