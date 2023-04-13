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
        public async Task<IEnumerable<RouletteModel>> Get()
        {
            return await _rouletteData.Get();           
        }
        // POST api/<RouletteController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] RouletteModel Item)
        {
            try
            {
                await _rouletteData.Insert(Item);
            }
            catch (Exception ex)
            {
                return Results.Conflict(ex);
            }
            return Results.Ok();
        }
        [HttpDelete]
        public async Task<IEnumerable<RouletteModel>> Get([FromBody] RouletteModel rouletteModel)
        {
            return await _rouletteData.Get();
        }
    }
}
