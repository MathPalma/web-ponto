using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessMySql
{
    public class BaseRepository
    {
        protected string ConnectionString { get; }

        protected BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public static IConfigurationRoot Configuration { get; set; }

        public MySqlConnection GetMySqlConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            string cs = ConnectionString;

            var csb = new MySqlConnectionStringBuilder(cs)
            {
                AllowZeroDateTime = allowZeroDatetime,
                ConvertZeroDateTime = convertZeroDatetime
            };
            var conn = new MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}
