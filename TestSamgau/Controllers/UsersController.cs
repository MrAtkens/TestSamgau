using Microsoft.AspNetCore.Mvc;
using TestSamgau.Contracts.Dtos;
using TestSamgau.Contracts.Parameters;
using TestSamgau.DataAccess.EntityProvider;
using TestSamgau.Services;

namespace TestSamgau.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/client/user/")]
    public class UsersController : ControllerBase
    {

        private readonly UserService _userService;
        private readonly IUserProvider _userProvider;

        public UsersController(UserService userService, IUserProvider userProvider)
        {
            _userService = userService;
            _userProvider = userProvider;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await _userService.GetUsers();
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var data = await _userService.GetUserById(id);
                return Ok(data);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserAddParameter parameter)
        {
            var user = await _userProvider.FirstOrDefault(x => x.Email.Equals(parameter.Email));
            if (user is not null)
            {
                return BadRequest("User with current email existed");
            }
            var userCreation = new UserCreationDto
            {
                Email = parameter.Email,
                FirstName = parameter.FirstName,
                LastName = parameter.LastName,
                Password = parameter.Password,
            };
            await _userService.AddUser(userCreation);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] UserEditParameter parameter)
        {
            var user = await _userService.GetUserById(id);
            await _userProvider.Edit(user, parameter);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userProvider.GetById(id);
            await _userProvider.Remove(user);
            return NoContent();
        }
    }
}
