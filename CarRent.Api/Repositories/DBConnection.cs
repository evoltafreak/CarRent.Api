using MySql.Data.MySqlClient;

namespace CarRent.Api.Repositories
{

    public class DBConnection
    {
        private DBConnection()
        {
        }

        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
            {
                _instance = new DBConnection();
            }
            return _instance;
        }

        public void Connect()
        {
            string connstring = "Server=localhost; database=CARRENT; UID=root; password=admin";
            connection = new MySqlConnection(connstring);
            connection.Open();
        }

        public void Close()
        {
            connection.Close();
        }
    }
}
