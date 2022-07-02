using Microsoft.AspNetCore.Mvc;
using Modsen.App.Core.Models.Dto;
using Modsen.App.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Modsen.App.Core.Models;

namespace Modsen.App.WebHost.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("id")]
        public async Task<UserDto> GetByIdAsync(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }
        [HttpGet("page")]
        public async Task<IEnumerable<UserDto>> GetByIdAsync([FromHeader(Name = "page_number")] int page, [FromHeader(Name = "page_size")]int size)
        {
            return await _userService.GetUserQueryAsync(page, size);
        }

        [HttpDelete("id")]
        public async Task DeleteByIdAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
        }

        [HttpPost("signup")]
        public async Task RegisterAsync([FromForm] User user)
        {
            await _userService.AddUserAsync(user);
        }
        [HttpPost("edit")]
        public async Task EditASync([FromForm] User user)
        {
            await _userService.UpdateUserAsync(user);
        }
    }
}
