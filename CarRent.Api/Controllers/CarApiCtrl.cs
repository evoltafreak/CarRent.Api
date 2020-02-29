using System.Collections.Generic;
using CarRent.Api.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAPI.Controllers;
using OpenAPI.Models;
using Car = OpenAPI.Models.Car;

namespace CarRent.Api.Controllers
{
    public class CarApiCtrl : CarApiController
    {
        private readonly ICarService _carService;
        public CarApiCtrl(ICarService carService)
        {
            _carService = carService;
        }

        public override IActionResult AddCar(Car car)
        {
            long idCar = _carService.AddCar(car);
            return StatusCode(200, idCar);
        }

        public override IActionResult DeleteCarById(long idCar)
        {
            int deleted = _carService.DeleteCarById(idCar);
            return StatusCode(200, deleted);
        }

        public override IActionResult ReadAllCarMakes()
        {
            List<CarMake> carMakeList = _carService.ReadAllCarMakes();
            return StatusCode(200, carMakeList);
        }

        public override IActionResult ReadAllCarTypes()
        {
            List<CarType> carTypeList = _carService.ReadAllCarTypes();
            return StatusCode(200, carTypeList);
        }

        public override IActionResult ReadAllCarClasses()
        {
            List<CarClass> carClassList = _carService.ReadAllCarClasses();
            return StatusCode(200, carClassList);
        }

        public override IActionResult ReadAllCars()
        {
            List<Car> carList = _carService.ReadAllCars();
            return StatusCode(200, carList);
        }

        public override IActionResult ReadCarById(long idCar)
        {
            Car car = _carService.ReadCarById(idCar);
            return car == null ? StatusCode(404, car) : StatusCode(200, car);
        }

        public override IActionResult UpdateCar(Car car)
        {
            long idCar = _carService.UpdateCar(car);
            return StatusCode(200, idCar);
        }
    }
}
