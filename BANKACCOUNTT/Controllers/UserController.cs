using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BANKACCOUNTT.Controllers
{
    public class UserController
    {
        [ApiController]
        [Route("apu/User/[controller]")]
        public class UserConroller : ControllerBase
        {
            private readonly IUserRepository _repository;
            public UserConroller(IUserRepository repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var userList = await _repository.GetAllAsync();
                return Ok(userList);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetUserById(int id)
            {
                var getId = await _repository.GetByIdAsync(id);
                if (getId == null)
                {
                    return NotFound();
                }
                return Ok(getId);
            }
            [HttpPost]
            public async Task<IActionResult> CreateUser(User user)
            {
                var createResult = await _repository.CreateUserAsync(user);
                return CreatedAtAction(nameof(CreateUser), new { user });
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> DeleteUser([FromRoute] int id)
            {
                var deletedResult = await _repository.DeleteUserAsync(id);
                if (deletedResult == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> UpdateUser(int id, User user)
            {
                var updatedUser = await
               _repository.UpdateUserAsync(id, user);

                if (updatedUser == null)
                {
                    return NotFound();
                }
                return Ok(updatedUser);
            }
        }
    }
}
