using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Services
{
    public interface ICarService
    {
        long AddCar(Car car);
        int DeleteCarById(long idCar);
        List<Car> ReadAllCars();
        Car ReadCarById(long idCar);
        long UpdateCar(Car car);
        List<CarType> ReadAllCarTypes();
        List<CarMake> ReadAllCarMakes();
        List<CarClass> ReadAllCarClasses();

    }
}
