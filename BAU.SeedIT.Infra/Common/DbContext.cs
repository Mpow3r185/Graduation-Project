using Bau.Seedit.Core.Common;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Bau.Seedit.Infra.Common
{
    public class DbContext : IDbContext
    {
        private DbConnection dbConnection;
        private readonly IConfiguration configuration;

        public DbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public DbConnection Connection
        {
            get
            {
                if (dbConnection == null)
                {
                    //Generate to connection
                    dbConnection = new MySqlConnection(configuration["ConnectionStrings:DbConnectionString"]);
                    dbConnection.Open();
                }
                else if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                return dbConnection;
            }
        }
    }
}
