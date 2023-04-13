using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Models;
using RouletteAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinController : ControllerBase
    {
        private ISpinData _spinData;

        public SpinController(ISpinData spinData)
        {
            _spinData = spinData;
        }
        // POST api/<SpinController>
        [HttpPost]
        public async Task<SpinResultModel> Post([FromBody] SpinModel value)
        {
            try
            {
                var result = new SpinResultModel
                {
                    AppName = value.AppName,
                    SessionID = value.SessionID,
                    User = value.User,
                    DateTime = value.DateTime
                };

                result.WinningNumber = new Random().Next(0, 36);
                result.Color = "Red"; // Logic to pull color based on number
                result.EvenOdd = result.WinningNumber % 2 == 0 ? "Even" : "Odd";
                _spinData.Insert(result);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        public async Task<IEnumerable<SpinResultModel>> Get()
        {
            try
            {
                return await _spinData.Get();
            }
            catch(Exception ex)
            {
                return null;
            }
        }


    }
}
