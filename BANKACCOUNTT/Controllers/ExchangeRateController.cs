using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BANKACCOUNTT.Controllers
{
    public class ExchangeRateController
    {
        [ApiController]
        [Route("apu/ExchangeRate/[controller]")]
        public class ExchangeRateConroller : ControllerBase
        {
            private readonly IExchangeRateRepository _repository;
            public ExchangeRateConroller(IExchangeRateRepository repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var exchangeRateList = await _repository.GetAllAsync();
                return Ok(exchangeRateList);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetExchangeRateById(int id)
            {
                var getId = await _repository.GetByIdAsync(id);
                if (getId == null)
                {
                    return NotFound();
                }
                return Ok(getId);
            }
            [HttpPost]
            public async Task<IActionResult> CreateExchangeRate(ExchangeRate exchangeRate)
            {
                var createResult = await _repository.CreateExchangeRateAsync(exchangeRate);
                return CreatedAtAction(nameof(CreateExchangeRate), new { exchangeRate });
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> DeleteExchangeRate([FromRoute] int id)
            {
                var deletedResult = await _repository.DeleteExchangeRateAsync(id);
                if (deletedResult == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> UpdateExchangeRate(int id, ExchangeRate exchangeRate)
            {
                var updatedExchangeRate = await
               _repository.UpdateExchangeRateAsync(id, exchangeRate);

                if (updatedExchangeRate == null)
                {
                    return NotFound();
                }
                return Ok(updatedExchangeRate);
            }
        }
    }
}
