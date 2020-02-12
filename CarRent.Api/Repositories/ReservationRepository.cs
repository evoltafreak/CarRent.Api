using MySql.Data.MySqlClient;
using System.Collections.Generic;
using CarRent.Api.Services;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class ReservationRepository: IReservationRepository
    {

        public DBConnection DbConnection;

        public ReservationRepository()
        {
            DbConnection = DBConnection.Instance();
        }

        public void AddReservation(Reservation reservation)
        {
            DbConnection.Connect();
            string query = "INSERT INTO Resevation (days, price, reservationNr, pickUpDate, isLease, fidCustomer, fidCar) VALUES (@days, @price, @reservationNr, @pickUpDate, @isLease, @fidCustomer, @fidCar)";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@days", reservation.Days);
            cmd.Parameters.AddWithValue("@price", reservation.Price);
            cmd.Parameters.AddWithValue("@reservationNr", reservation.ReservationNr);
            cmd.Parameters.AddWithValue("@pickUpDate", reservation.PickUpDate);
            cmd.Parameters.AddWithValue("@isLease", reservation.IsLease);
            cmd.Parameters.AddWithValue("@fidCustomer", reservation.Customer.IdCustomer);
            cmd.Parameters.AddWithValue("@fidCar", reservation.Car.IdCar);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }

        public void DeleteReservationById(long idReservation)
        {
            DbConnection.Connect();
            string query = "DELETE FROM Reservation WHERE idREservation = @idReservation";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idReservation", idReservation);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }


        public List<Reservation> ReadAllReservation()
        {
            List<Reservation> reservationList = new List<Reservation>();
            DbConnection.Connect();

            string query = "SELECT * FROM VW_RESERVATION";
            var cmd = new MySqlCommand(query, DbConnection.Connection);
            var reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                Reservation reservation = new Reservation();
                reservation.IdReservation = reader.GetInt32(0);
                reservation.Days = reader.GetInt32(1);
                reservation.Price = reader.GetDecimal(2);
                reservation.ReservationNr = reader.GetString(3);
                reservation.PickUpDate = reader.GetDateTime(4);
                reservation.IsLease = reader.GetBoolean(5);

                Customer customer = new Customer();
                customer.Firstname = reader.GetString(6);
                customer.Lastname = reader.GetString(7);
                reservation.Customer = customer;

                Car car = new Car();
                car.CarName = reader.GetString(8);
                car.CarNr = reader.GetString(9);
                reservation.Car = car;

                reservationList.Add(reservation);
            }
            DbConnection.Close();
            return reservationList;
        }

        public Reservation ReadReservationById(long idReservation)
        {
            Reservation reservation = new Reservation();
            DbConnection.Connect();

            string query = "SELECT * FROM VW_RESERVATION WHERE idReservation = @idReservation";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idReservation", idReservation);
            cmd.Prepare();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reservation.IdReservation = reader.GetInt32(0);
                reservation.Days = reader.GetInt32(1);
                reservation.Price = reader.GetDecimal(2);
                reservation.ReservationNr = reader.GetString(3);
                reservation.PickUpDate = reader.GetDateTime(4);
                reservation.IsLease = reader.GetBoolean(5);

                Customer customer = new Customer();
                customer.IdCustomer = reader.GetInt64(6);
                customer.Firstname = reader.GetString(7);
                customer.Lastname = reader.GetString(8);
                reservation.Customer = customer;

                Car car = new Car();
                car.IdCar = reader.GetInt64(9);
                car.CarName = reader.GetString(10);
                car.CarNr = reader.GetString(11);
                reservation.Car = car;
            }
            DbConnection.Close();
            return reservation;
        }

        public void UpdateReservation(Reservation reservation)
        {
            DbConnection.Connect();
            string query = "UPDATE Reservation SET days = @days, price = @price, reservationNr = @reservationNr, pickUpDate = @pickUpDate, isLease = @isLease, fidCustomer = @fidCustomer, fidCar = @fidCar WHERE idReservation = @idReservation";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@days", reservation.Days);
            cmd.Parameters.AddWithValue("@price", reservation.Price);
            cmd.Parameters.AddWithValue("@reservationNr", reservation.ReservationNr);
            cmd.Parameters.AddWithValue("@pickUpDate", reservation.PickUpDate);
            cmd.Parameters.AddWithValue("@isLease", reservation.IsLease);
            cmd.Parameters.AddWithValue("@fidCustomer", reservation.Customer.IdCustomer);
            cmd.Parameters.AddWithValue("@fidCar", reservation.Car.IdCar);
            cmd.Parameters.AddWithValue("@idReservation", reservation.IdReservation);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }

    }
}
