using Dapper;
using Microsoft.Data.Sqlite;
using RouletteAPI.Database;
using RouletteAPI.Models;

namespace RouletteAPI.Repository
{
    public interface IRouletteData
    {
        Task<IEnumerable<RouletteModel>> Get();
        Task Insert(RouletteModel rouletteModel);        
    }
}
