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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<SpinResultModel>> Post([FromBody] SpinModel value)
        {
            var existingItem = _spinData.Get(value.SessionID).Result;
            if (existingItem != null)
            {
                return BadRequest("Operation cannot be repeated.");
            }

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
            await _spinData.Insert(result);
            return Ok(result);

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpinResultModel>>> Get()
        {
            var result = await _spinData.Get();
            return Ok(result);

        }


    }
}
