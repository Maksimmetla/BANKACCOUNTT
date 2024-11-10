using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BANKACCOUNTT.Controllers
{
    public class TransactionTypeController
    {
        [ApiController]
        [Route("apu/TransactionType/[controller]")]
        public class TransactionTypeConroller : ControllerBase
        {
            private readonly ITransactionTypeRepository _repository;
            public TransactionTypeConroller(ITransactionTypeRepository repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var transactionTypeList = await _repository.GetAllAsync();
                return Ok(transactionTypeList);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetTransactionTypeById(int id)
            {
                var getId = await _repository.GetByIdAsync(id);
                if (getId == null)
                {
                    return NotFound();
                }
                return Ok(getId);
            }
            [HttpPost]
            public async Task<IActionResult> CreateTransactionType(TransactionType transactionType)
            {
                var createResult = await _repository.CreateTransactionTypeAsync(transactionType);
                return CreatedAtAction(nameof(CreateTransactionType), new { transactionType });
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> DeleteHomeAdre([FromRoute] int id)
            {
                var deletedResult = await _repository.DeleteTransactionTypeAsync(id);
                if (deletedResult == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> UpdateTransactionType(int id, TransactionType transactionType)
            {
                var updatedTransactionType = await
               _repository.UpdateTransactionTypeAsync(id, transactionType);

                if (updatedTransactionType == null)
                {
                    return NotFound();
                }
                return Ok(updatedTransactionType);
            }
        }
    }
}
