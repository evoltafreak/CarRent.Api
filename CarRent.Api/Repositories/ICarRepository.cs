using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public interface ICarRepository
    {
        void AddCar(Car car);
        void DeleteCarById(long idCar);
        List<Car> ReadAllCars();
        Car ReadCarById(long idCar);
        void UpdateCar(Car car);
        List<CarType> ReadAllCarTypes();
        List<CarMake> ReadAllCarMakes();
    }
}
