using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Store.Services.Core;
using Store.ViewModels.Authentication;

namespace Store.Application.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class RolesController: ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPagedResult(int pageIndex = 0, int pageSize = Int32.MaxValue)
        {
            var result = await _roleService.GetPagedResult(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var result = await _roleService.Get(id);
            return Ok(result);
        }

        [HttpGet("{id}/Permission")]
        public async Task<ActionResult> GetPermission([FromRoute] int id)
        {
            var result = await _roleService.GetPermission(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleAddModel model)
        {
            var result = await _roleService.Create(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] RoleUpdateModel model, [FromRoute] int id)
        {
            var result = await _roleService.Update(model, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _roleService.Delete(id);
            return Ok(result);
        }

        [HttpPost("{id}/AddUser")]
        public async Task<ActionResult> AddUser([FromBody] AddUserToRoleModel model, [FromRoute] int id)
        {
            var result = await _roleService.AddUser(model, id);
            return Ok(result);
        }

        [HttpPut("{id}/RemoveUser")]
        public async Task<ActionResult> RemoveUser([FromBody] RemoveUserOfRoleModel model, [FromRoute] int id)
        {
            var result = await _roleService.RemoveUser(model, id);
            return Ok(result);
        }

        [HttpPost("{id}/AddPermission")]
        public async Task<ActionResult> AddPermission([FromBody] AddPermissionToRoleModel model, [FromRoute] int id)
        {
            var result = await _roleService.AddPermission(model, id);
            return Ok(result);
        }

        [HttpPut("{id}/RemovePermission")]
        public async Task<ActionResult> RemovePermission([FromBody] RemovePermissionOfRoleModel model, [FromRoute] int id)
        {
            var result = await _roleService.RemovePermission(model, id);
            return Ok(result);
        }
    }
}
