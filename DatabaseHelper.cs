using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public static class DatabaseHelper
    {
        private static string connectionString = "datasource=sql12.freesqldatabase.com;port=3306;username=sql12647212;password=31a2n6pHbR;database=sql12647212;";

        public static MySqlConnection GetOpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("DBHP: An error occurred while opening the database connection: " + ex.Message);
                connection.Close();
                connection = null;
            }

            return connection;
        }
        public static void CloseConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

    }
}
