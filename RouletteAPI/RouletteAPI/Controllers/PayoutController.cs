using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Models;
using RouletteAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayoutController : ControllerBase
    {
        private ISpinData _spinData;
        private IRouletteData _rouletteData;

        public PayoutController(ISpinData spinData, IRouletteData rouletteData)
        {
            _spinData = spinData;
            _rouletteData = rouletteData;
        }
        // GET api/<Payout>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<PayoutModel>>> Get(string sessionid)
        {
            var result = new List<PayoutModel>();
            var Bets = await _rouletteData.Get(sessionid);
            var winner = await _spinData.Get(sessionid);
            foreach (var winningItem in Bets.Where(o => o.BetOn == winner.WinningNumber))
            {
                int winningAmount = 0;
                if (winningItem.GroupBetID != null)
                {
                    var actualBetAmount = winningItem.Token / Bets.Where(o => o.GroupBetID == winningItem.GroupBetID).Count(); //Treating Token as a real amount for now ex- Token 10 will cost 10 Rand in real
                    winningAmount = actualBetAmount * 36;
                }
                else
                {
                    winningAmount = winningItem.Token * 36;
                }
                var newItem = MappPayout(winningItem);
                newItem.WinningAmount = winningAmount;
                result.Add(newItem);
            }
            foreach (var winningItem in Bets.Where(o => o.Color == winner.Color))
            {              
                var newItem = MappPayout(winningItem);
                newItem.WinningAmount = winningItem.Token * 2;
                result.Add(newItem);
            }
            foreach (var winningItem in Bets.Where(o => o.EvenOdd == winner.EvenOdd))
            {
               
                var newItem = MappPayout(winningItem);
                newItem.WinningAmount = winningItem.Token * 2;
                result.Add(newItem);
            }
            return Ok(result);
        }
        private PayoutModel MappPayout(RouletteModel winningItem)
        {
            return new PayoutModel
            {
                AppName = winningItem.AppName,
                Color = winningItem.Color,
                DateTime = winningItem.DateTime,
                EvenOdd = winningItem.EvenOdd,
                SessionID = winningItem.SessionID,
                User = winningItem.User,
                WinningNumber = winningItem.BetOn
            };
        }

    }
}
