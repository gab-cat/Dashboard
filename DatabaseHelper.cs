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
        private static string connectionString = "";

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

        public static MySqlConnection GetAsyncConnection()
        {
            MySqlConnection async_connection = new MySqlConnection(connectionString);
            try
            {
                if (async_connection.State != ConnectionState.Open)
                {
                    async_connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("DBHP: An error occurred while opening the database connection: " + ex.Message);
                async_connection.Close();
                async_connection = null;
            }
            return async_connection;
        }

        public static MySqlConnection GetMemoConnection()
        {
            MySqlConnection memoConnection = new MySqlConnection(connectionString);
            try
            {
                if (memoConnection.State != ConnectionState.Open)
                {
                    memoConnection.Open();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("DBHP: An error occurred while opening the database connection: " + ex.Message);
                memoConnection.Close();
                memoConnection = null;
            }
            return memoConnection;
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
