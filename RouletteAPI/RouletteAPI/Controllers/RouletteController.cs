using Microsoft.AspNetCore.Mvc;
using RouletteAPI.Models;
using RouletteAPI.Repository;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private IRouletteData _rouletteData;

        public RouletteController(IRouletteData rouletteData)
        {
            _rouletteData = rouletteData;
        }
        // GET: api/<RouletteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RouletteModel>>> Get()
        {          
            var result= await _rouletteData.Get();
            return Ok(result);
        }
        // POST api/<RouletteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RouletteModel Item)
        {
            await _rouletteData.Insert(Item);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] RouletteModel rouletteModel)
        {
            var result = await _rouletteData.Get();
            return Ok(result);
        }
    }
}
