using Dapper;
using Microsoft.Data.Sqlite;
using RouletteAPI.Database;
using RouletteAPI.Models;

namespace RouletteAPI.Repository
{
    public class RouletteData:IRouletteData
    {
        private readonly IConfiguration _configuration;
        public RouletteData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<RouletteModel>> Get()
        {
            using var connection = new SqliteConnection(_configuration.GetSection("DatabaseName").Value);

            return await connection.QueryAsync<RouletteModel>("SELECT * FROM RouletteDetails;");
        }
        public async Task Insert(RouletteModel rouletteModel)
        {
            using var connection = new SqliteConnection(_configuration.GetSection("DatabaseName").Value);

            await connection.ExecuteAsync("INSERT INTO RouletteDetails (BetOn,Token,Color,EvenOdd,GroupBetID,SessionID,User,DateTime,AppName)" +
                "VALUES (@BetOn,@Token,@Color,@EvenOdd,@GroupBetID,@SessionID,@User,@DateTime,@AppName);", rouletteModel);
        }
    }
}
