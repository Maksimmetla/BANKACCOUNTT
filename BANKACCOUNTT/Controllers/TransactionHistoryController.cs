using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BANKACCOUNTT.Controllers
{
    public class TransactionHistoryController
    {
        [ApiController]
        [Route("apu/ TransactionHistory/[controller]")]
        public class TransactionHistoryConroller : ControllerBase
        {
            private readonly ITransactionHistoryRepository _repository;
            public TransactionHistoryConroller(ITransactionHistoryRepository repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var transactionHistoryList = await _repository.GetAllAsync();
                return Ok(transactionHistoryList);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetTransactionHistoryById(int id)
            {
                var getId = await _repository.GetByIdAsync(id);
                if (getId == null)
                {
                    return NotFound();
                }
                return Ok(getId);
            }
            [HttpPost]
            public async Task<IActionResult> CreateTransactionHistory(TransactionHistory transactionHistory)
            {
                var createResult = await _repository.CreateTransactionHistoryAsync(transactionHistory);
                return CreatedAtAction(nameof(CreateTransactionHistory), new { transactionHistory });
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> DeleteTransactionHistory([FromRoute] int id)
            {
                var deletedResult = await _repository.DeleteTransactionHistoryAsync(id);
                if (deletedResult == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> UpdateTransactionHistory(int id, TransactionHistory transactionHistory)
            {
                var updatedTransactionHistory = await
               _repository.UpdateTransactionHistoryAsync(id, transactionHistory);

                if (updatedTransactionHistory == null)
                {
                    return NotFound();
                }
                return Ok(updatedTransactionHistory);
            }
        }
    }
}
