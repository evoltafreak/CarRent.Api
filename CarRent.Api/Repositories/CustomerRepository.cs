using MySql.Data.MySqlClient;
using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        public DBConnection DbConnection;

        public CustomerRepository()
        {
            DbConnection = DBConnection.Instance();
        }

        public void AddCustomer(Customer customer)
        {
            DbConnection.Connect();
            string query = "INSERT INTO (firstname, lastname, address, addressNr, fidPlace) VALUES (@firstname, @lastname, @address, @addressNr, @fidPlace)";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@firstname", customer.Firstname);
            cmd.Parameters.AddWithValue("@lastname", customer.Lastname);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@addressNr", customer.AddressNr);
            cmd.Parameters.AddWithValue("@fidPlace", customer.Place.IdPlace);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }

        public void DeleteCustomerById(long idCustomer)
        {
            DbConnection.Connect();
            string query = "DELETE FROM Customer WHERE idCustomer = @idCustomer";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }


        public List<Customer> ReadAllCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            DbConnection.Connect();

            string query = "SELECT * FROM VW_CUSTOMER";
            var cmd = new MySqlCommand(query, DbConnection.Connection);
            var reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.IdCustomer = reader.GetInt32(0);
                customer.Firstname = reader.GetString(1);
                customer.Lastname = reader.GetString(2);
                customer.Address = reader.GetString(3);
                customer.AddressNr = reader.GetString(4);
                Place place = new Place();
                place.IdPlace = reader.GetInt32(5);
                place.ZipCode = reader.GetString(6);
                place._Place = reader.GetString(7);
                customer.Place = place;
                customerList.Add(customer);
            }
            DbConnection.Close();
            return customerList;
        }

        public Customer ReadCustomerById(long idCustomer)
        {
            Customer customer = new Customer();
            DbConnection.Connect();

            string query = "SELECT * FROM VW_CUSTOMER WHERE idCustomer = @idCustomer";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
            cmd.Prepare();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                customer.IdCustomer = reader.GetInt32(0);
                customer.Firstname = reader.GetString(1);
                customer.Lastname = reader.GetString(2);
                customer.Address = reader.GetString(3);
                customer.AddressNr = reader.GetString(4);
                Place place = new Place();
                place.IdPlace = reader.GetInt32(5);
                place.ZipCode = reader.GetString(6);
                place._Place = reader.GetString(7);
                customer.Place = place;
            }
            DbConnection.Close();
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            DbConnection.Connect();
            string query = "UPDATE Customer SET firstname = @firstname, lastname = @lastname, address = @address, addressNr = @addressNr, fidPlace = @fidPlace WHERE idCustomer = @idCustomer";
            MySqlCommand cmd = new MySqlCommand(query, DbConnection.Connection);
            cmd.Parameters.AddWithValue("@firstname", customer.Firstname);
            cmd.Parameters.AddWithValue("@lastname", customer.Lastname);
            cmd.Parameters.AddWithValue("@address", customer.Address);
            cmd.Parameters.AddWithValue("@addressNr", customer.AddressNr);
            cmd.Parameters.AddWithValue("@fidPlace", customer.Place.IdPlace);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            DbConnection.Close();
        }

    }
}
