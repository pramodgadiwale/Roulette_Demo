using Dapper;
using Microsoft.Data.Sqlite;
using RouletteAPI.Database;
using RouletteAPI.Models;

namespace RouletteAPI.Repository
{
    public interface ISpinData
    {
        Task<IEnumerable<SpinResultModel>> Get();
        Task<SpinResultModel> Get(string sessionID);
        Task Insert(SpinResultModel rouletteModel);        
    }
}
