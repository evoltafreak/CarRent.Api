using MySql.Data.MySqlClient;
using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class CarRepository: ICarRepository
    {

        public DBConnection DbConnection;

        public CarRepository()
        {
            DbConnection = DBConnection.Instance();
        }

        public void AddCar(Car car)
        {
            DbConnection.Connect();
            string query = "INSERT INTO (fidCarType, carName, fidCarMake, fee) VALUES (@fidCarType, @carName, @fidCarMake, @fee)";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idCar", car.IdCar);
            cmd.Parameters.AddWithValue("@fidCarType", car.CarType.IdCarType);
            cmd.Parameters.AddWithValue("@carName", car.CarName);
            cmd.Parameters.AddWithValue("@carNr", car.CarNr);
            cmd.Parameters.AddWithValue("@fidCarMake", car.CarMake.IdCarMake);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }

        public void DeleteCarById(long idCar)
        {
            DbConnection.Connect();
            string query = "DELETE FROM Car WHERE idCar = @idCar";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idCar", idCar);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }


        public List<Car> ReadAllCars()
        {
            List<Car> carList = new List<Car>();
            DbConnection.Connect();

            string query = "SELECT * FROM VW_CARS";
            var cmd = new MySqlCommand(query, DbConnection.Connection);
            var reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                Car car = new Car();
                car.IdCar = reader.GetInt32(0);
                car.CarName = reader.GetString(1);
                car.CarNr = reader.GetString(2);
                CarType carType = new CarType();
                carType._CarType = reader.GetString(3);
                car.CarType = carType;
                CarMake carMake = new CarMake();
                carMake._CarMake = reader.GetString(4);
                car.CarMake = carMake;
                CarClass carClass = new CarClass();
                carClass._CarClass = reader.GetString(5);
                car.CarClass = carClass;
                carList.Add(car);
            }
            DbConnection.Close();
            return carList;
        }

        public Car ReadCarById(long idCar)
        {
            Car car = new Car();
            DbConnection.Connect();

            string query = "SELECT * FROM VW_CARS WHERE idCar = @idCar";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idCar", idCar);
            cmd.Prepare();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                car.IdCar = reader.GetInt32(0);
                car.CarName = reader.GetString(1);
                car.CarNr = reader.GetString(2);
                CarType carType = new CarType();
                carType._CarType = reader.GetString(3);
                car.CarType = carType;
                CarMake carMake = new CarMake();
                carMake._CarMake = reader.GetString(4);
                car.CarMake = carMake;
                CarClass carClass = new CarClass();
                carClass._CarClass = reader.GetString(5);
                car.CarClass = carClass;
            }
            DbConnection.Close();
            return car;
        }

        public void UpdateCar(Car car)
        {
            DbConnection.Connect();
            string query = "UPDATE CAR SET fidCarType = @fidCarType, carName = @carName, fidCarMake = @fidCarMake, fee = @fee WHERE idCar = @idCar";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idCar", car.IdCar);
            cmd.Parameters.AddWithValue("@fidCarType", car.CarType.IdCarType);
            cmd.Parameters.AddWithValue("@carName", car.CarName);
            cmd.Parameters.AddWithValue("@carNr", car.CarNr);
            cmd.Parameters.AddWithValue("@fidCarMake", car.CarMake.IdCarMake);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }

        public List<CarType> ReadAllCarTypes()
        {
            List<CarType> carTypeList = new List<CarType>();
            DbConnection.Connect();

            string query = "SELECT * FROM CarType";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CarType carType = new CarType();
                carType.IdCarType = reader.GetInt32(0);
                carType._CarType = reader.GetString(1);
                carTypeList.Add(carType);
            }
            DbConnection.Close();
            return carTypeList;
        }

        public List<CarMake> ReadAllCarMakes()
        {
            List<CarMake> carMakeList = new List<CarMake>();
            DbConnection.Connect();

            string query = "SELECT * FROM CarMake";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CarMake carMake = new CarMake();
                carMake.IdCarMake = reader.GetInt32(0);
                carMake._CarMake = reader.GetString(1);
                carMakeList.Add(carMake);
            }
            DbConnection.Close();
            return carMakeList;
        }
    }
}
