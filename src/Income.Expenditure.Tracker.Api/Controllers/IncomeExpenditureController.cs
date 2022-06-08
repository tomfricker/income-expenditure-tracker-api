using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Income.Expenditure.Tracker.Api.Models;
using Income.Expenditure.Tracker.Api.Services.Contracts;

namespace Income.Expenditure.Tracker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncomeExpenditureController : ControllerBase
    {
        private readonly IDbService _dbService;

        public IncomeExpenditureController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbService.GetItemsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var incomeExpenditure = await _dbService.GetItemAsync(id);

            if (incomeExpenditure == null)
            {
                return NotFound();
            }

            return Ok(incomeExpenditure);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item incomeExpenditure)
        {
            if (incomeExpenditure == null)
            {
                return BadRequest("Please details in the body of your request");
            }

            var id = Guid.NewGuid();

            incomeExpenditure.Id = id.ToString();

            await _dbService.AddItemAsync(incomeExpenditure);

            return Created("", new { id = incomeExpenditure.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Item incomeExpenditure)
        {
            await _dbService.UpdateItemAsync(incomeExpenditure.Id, incomeExpenditure);
            return Accepted();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _dbService.DeleteItemAsync(id);
            return Accepted();
        }
    }
}
