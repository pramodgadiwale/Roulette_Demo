using Dapper;
using Microsoft.Data.Sqlite;
using RouletteAPI.Models;

namespace RouletteAPI.Repository
{
    public class SpinData : ISpinData
    {
        private readonly IConfiguration _configuration;
        public SpinData(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<SpinResultModel>> Get()
        {
            using var connection = new SqliteConnection(_configuration.GetSection("DatabaseName").Value);

            return await connection.QueryAsync<SpinResultModel>("SELECT * FROM SpinDetails;");
        }
        public async Task Insert(SpinResultModel SpinModel)
        {
            using var connection = new SqliteConnection(_configuration.GetSection("DatabaseName").Value);

            await connection.ExecuteAsync("INSERT INTO SpinDetails (WinningNumber,Color,EvenOdd,GroupBetID,SessionID,User,DateTime,AppName)" +
                "VALUES (@WinningNumber,@Color,@EvenOdd,@GroupBetID,@SessionID,@User,@DateTime,@AppName);", SpinModel);
        }
    }
}
