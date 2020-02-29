using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public interface ICarRepository
    {
        long AddCar(Car car);
        int DeleteCarById(long idCar);
        List<Car> ReadAllCars();
        Car ReadCarById(long idCar);
        long UpdateCar(Car car);
        CarType ReadCarTypeById(long idCarType);
        List<CarType> ReadAllCarTypes();
        CarMake ReadCarMakeById(long idCarMake);
        List<CarMake> ReadAllCarMakes();
        CarClass ReadCarClassById(long idCarClass);
        List<CarClass> ReadAllCarClasses();
    }
}
