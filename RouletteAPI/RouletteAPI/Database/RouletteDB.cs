using Microsoft.Data.Sqlite;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace RouletteAPI.Database
{
    public class RouletteDB:IRouletteDB
    {
        
        private readonly IConfiguration _configuration;
        public RouletteDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(_configuration.GetSection("DatabaseName").Value);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'RouletteDetails';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "RouletteDetails")
                return;

            connection.Execute("Create Table RouletteDetails (" +
                "BetOn int NOT NULL," +
                "Token int NOT NULL," +
                "Color VARCHAR(10) NULL," +
                "EvenOdd VARCHAR(10) NULL," +
                "GroupBetID VARCHAR(100) NULL," +
                "SessionID VARCHAR(100) NOT NULL," +
                "User VARCHAR(100) NOT NULL," +
                "AppName VARCHAR(100) NOT NULL," +
                "DateTime DateTime NULL);");
            connection.Execute("Create Table SpinDetails (" +
              "WinningNumber int NOT NULL,"+
               "Color VARCHAR(10) NOT NULL," +
               "EvenOdd VARCHAR(10) NOT NULL," +            
               "SessionID VARCHAR(100) NOT NULL," +
               "User VARCHAR(100) NOT NULL," +
               "AppName VARCHAR(100) NOT NULL," +
               "DateTime DateTime NULL);");
        }
    }
}
