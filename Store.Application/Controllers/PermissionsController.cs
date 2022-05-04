using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Net;
using System.Threading.Tasks;
using Store.Application.Extensions;
using Store.Services.Core;
using Store.ViewModels.Authentication;

namespace Store.Application.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionsController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult> GetPagedResult(int pageIndex = 0, int pageSize = Int32.MaxValue)
        {
            var result = await _permissionService.GetPagedResult(pageIndex, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            var result = await _permissionService.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PermissionAddModel model)
        {
            var result = await _permissionService.Create(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] PermissionUpdateModel model, [FromRoute] int id)
        {
            var result = await _permissionService.Update(model, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _permissionService.Delete(id);
            return Ok(result);
        }

        [HttpPost("{id}/AddUser")]
        public async Task<ActionResult> AddUser([FromBody] AddPermissionToUserModel model, [FromRoute] int id)
        {
            var result = await _permissionService.AddUser(model, id);
            return Ok(result);
        }

        [HttpPut("{id}/RemoveUser")]
        public async Task<ActionResult> RemoveUser([FromBody] RemovePermissionOfUserModel model, [FromRoute] int id)
        {
            var result = await _permissionService.RemoveUser(model, id);
            return Ok(result);
        }
    }
}
