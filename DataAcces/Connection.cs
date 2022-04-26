using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAcces
{
    public class Connection : IDbConnection
    {
        SqlConnection connection = null;

<<<<<<< HEAD
        public string connectionString = @"data Source=PC-224;Database=Vivero;User Instance=false; Integrated Security=True";
=======
        public string connectionString = @"data Source=localhost\SQLEXPRESS;Database=Vivero;User Instance=false; Integrated Security=True";
>>>>>>> 274020364cdf49c3110d98861dbe951f7e8cdb59
        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public int ConnectionTimeout => connection.ConnectionTimeout;
        // Constructor de Connection
        public Connection()
        {
            connection = new SqlConnection(connectionString);
        }

        public string Database => connection.Database;

        public ConnectionState State => connection.State;

        public IDbTransaction BeginTransaction()
        {
            return connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            connection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return connection.CreateCommand();
        }

        public void Dispose()
        {
            connection.Dispose();
        }

        public void Open()
        {
            connection.Open();
        }
    }
}
