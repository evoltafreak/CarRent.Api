using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public interface ICarRepository
    {
        long AddCar(Car car);
        void DeleteCarById(long idCar);
        List<Car> ReadAllCars();
        Car ReadCarById(long idCar);
        void UpdateCar(Car car);
        CarType ReadCarTypeById(long idCarType);
        List<CarType> ReadAllCarTypes();
        CarMake ReadCarMakeById(long idCarMake);
        List<CarMake> ReadAllCarMakes();
        CarClass ReadCarClassById(long idCarClass);
        List<CarClass> ReadAllCarClasses();
    }
}
