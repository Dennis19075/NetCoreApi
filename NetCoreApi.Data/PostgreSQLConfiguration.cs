using System;
namespace NetCoreApi.Data
{
    public class PostgreSQLConfiguration
    {

        public PostgreSQLConfiguration(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }



    }
}

