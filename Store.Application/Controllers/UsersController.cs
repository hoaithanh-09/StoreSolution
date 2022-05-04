using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Store.Application.Extensions;
using Store.Services.Core;
using Store.ViewModels.Authentication;

namespace Store.Application.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedResult([FromQuery] UserFilter filter)
        {
            var result = await _userService.GetPagedResult(filter);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("Permission")]
        public async Task<IActionResult> GetPermissionOfUser()
        {
            var userId = User.GetUserId();
            if (!userId.HasValue)
                return Unauthorized();

            var result = await _userService.GetPermissionCodeOfUser(userId.Value);
            if (!result.Succeed)
                return BadRequest(result.ErrorMessages);
            return Ok(result);
        }

        [HttpGet("{id}/Permission")]
        public async Task<IActionResult> GetPermissionOfUser([FromRoute] int id)
        {
            var result = await _userService.GetPermissionDetailOfUser(id);
            if (!result.Succeed)
                return BadRequest(result.ErrorMessages);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _userService.Login(model);
            if (!result.Succeed)
                return BadRequest(result.ErrorMessages);
            return Ok(result);
        }
    }
}
