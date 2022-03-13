using System;
using System.Collections.Generic;
using System.Text;

namespace TCC.Backend.Infrastructure
{
    public static class Config
    {
        public static class SqlServer
        {
            public static string ConnectionString => Environment.GetEnvironmentVariable("SQL_SERVER");
            public static string Usuario => Environment.GetEnvironmentVariable("DB_NETCORE_SQL_USR");
            public static string Senha => Environment.GetEnvironmentVariable("DB_NETCORE_SQL_PWD");
        }
    }
}
