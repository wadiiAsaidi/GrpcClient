using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayer.DataAccess
{

    public enum EFDriver
    {
        SqlServer,
        PostgreSQL,
        MySQL
    }

    public static class DatabaseProvider
    {

        public static DbContextOptions<DbContext> AlterConnectionString(string connectionString)
        {
            var contextOptions = GetDbDriver(EFDriver.SqlServer, AlterConnectionString(connectionString, ApplicationIntent.ReadWrite));

            return contextOptions;
        }

        private static string AlterConnectionString(string connectionString, ApplicationIntent accessType)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            builder.ApplicationIntent = accessType;
            return connectionString;
        }
        private static DbContextOptions<DbContext> GetDbDriver(EFDriver driverType, string connectionString)
        {
            var contextOptions = new DbContextOptions<DbContext>();

            switch (driverType)
            {
                case EFDriver.SqlServer:
                    contextOptions = new DbContextOptionsBuilder<DbContext>()
                                   .UseSqlServer(connectionString)
                                   .Options;
                    break;

                case EFDriver.PostgreSQL:
                    contextOptions = new DbContextOptionsBuilder<DbContext>()
                                   .UseNpgsql(connectionString)
                                   .Options;
                    break;

                case EFDriver.MySQL:
                    contextOptions = new DbContextOptionsBuilder<DbContext>()
                                   .UseMySql(connectionString)
                                   .Options;
                    break;

                default:
                    break;
            }

            return contextOptions;

        }
    }
}
