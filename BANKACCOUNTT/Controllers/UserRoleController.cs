using BANKACCOUNTT.Interfaces;
using BANKACCOUNTT.Models;
using Microsoft.AspNetCore.Mvc;

namespace BANKACCOUNTT.Controllers
{
    public class UserRoleController
    {
        [ApiController]
        [Route("apu/UserRole/[controller]")]
        public class UserRoleConroller : ControllerBase
        {
            private readonly IUserRoleRepository _repository;
            public UserRoleConroller(IUserRoleRepository repository)
            {
                _repository = repository;
            }
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var userRoleList = await _repository.GetAllAsync();
                return Ok(userRoleList);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetUserRoleById(int id)
            {
                var getId = await _repository.GetByIdAsync(id);
                if (getId == null)
                {
                    return NotFound();
                }
                return Ok(getId);
            }
            [HttpPost]
            public async Task<IActionResult> CreateUserRole(UserRole userRole)
            {
                var createResult = await _repository.CreateUserRoleAsync(userRole);
                return CreatedAtAction(nameof(CreateUserRole), new { userRole });
            }
            [HttpDelete]
            [Route("{id}")]
            public async Task<IActionResult> DeleteUserRole([FromRoute] int id)
            {
                var deletedResult = await _repository.DeleteUserRoleAsync(id);
                if (deletedResult == false)
                {
                    return NotFound();
                }
                return NoContent();
            }
            [HttpPut]
            [Route("{id}")]
            public async Task<IActionResult> UpdateUserRole(int id, UserRole userRole)
            {
                var updatedUserRole = await
               _repository.UpdateUserRoleAsync(id, userRole);

                if (updatedUserRole == null)
                {
                    return NotFound();
                }
                return Ok(updatedUserRole);
            }
        }
    }
}
