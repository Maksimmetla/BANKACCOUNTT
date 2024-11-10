using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BANKACCOUNTT.Controllers
{
    public class HomeAdreController
    {
        [ApiController]
        [Route("apu/HomeAdre/[controller]")]
        public class HomeAdreConroller : ControllerBase
        {
            private readonly IHomeAdreRepository _repository;
            public HomeAdreConroller(IHomeAdreRepository repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var homeAdreList = await _repository.GetAllAsync();
                return Ok(homeAdreList);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetHomeAdreById(int id)
            {
                var getId = await _repository.GetByIdAsync(id);
                if (getId == null)
                {
                    return NotFound();
                }
                return Ok(getId);
            }
            [HttpPost]
            public async Task<IActionResult> CreateHomeAdre(HomeAdre homeAdre)
            {
                var createResult = await _repository.CreateHomeAdreAsync(homeAdre);
                return CreatedAtAction(nameof(CreateHomeAdre), new { homeAdre });
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> DeleteHomeAdre([FromRoute] int id)
            {
                var deletedResult = await _repository.DeleteHomeAdreAsync(id);
                if (deletedResult == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> UpdateHomeAdre(int id, HomeAdre homeAdre)
            {
                var updatedHomeAdre = await
               _repository.UpdateHomeAdreAsync(id, homeAdre);

                if (updatedHomeAdre == null)
                {
                    return NotFound();
                }
                return Ok(updatedHomeAdre);
            }
        }
    }
}
