using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TCC.Backend.Domain.Repositories.Base;

namespace TCC.Backend.Infrastructure.Repositories.Base
{
    public class ConnectionFactory : IConnectionFactory
    {
        private bool InTransaction { get; set; }

        public ConnectionFactory()
        {
        }

        public IDbConnection GetIDbConnection()
        {
            var connectionString = "server=127.0.0.1;uid=foxen;pwd=foxenadmin;database=foxen";// Config.SqlServer.ConnectionString;

            if (connectionString == null)
                throw new DataException("Não foi possível encontrar a string de conexão para o SQL Server");

            return GetConnectionMSSQL(connectionString);
        }

        private static void CheckNullConnection(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new DataException("Não foi possível criar uma conexão para o SQL Server");
            }
        }

        private static IDbConnection GetConnectionMSSQL(string connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            CheckNullConnection(connection);
            connection.Open();

            return connection;
        }

        public void Begin()
        {
            InTransaction = true;
        }

        public void End()
        {
            InTransaction = true;
        }
    }
}
