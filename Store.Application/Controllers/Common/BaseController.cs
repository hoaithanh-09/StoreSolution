using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Store.Services.Core;
using Store.Application.Extensions;

namespace Store.Application.Controllers.Common
{
	/*
		Generic
		- E: Entity
		- F: Filter model
		- V: View model
		- A: Add model
		- U: Update model
	*/

	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BaseController<E, F, V, A, U> : ControllerBase where E : class where F : class where V : class where A : class where U : class
	{
		private readonly IBaseService<E, F, V, A, U> _service;

		public BaseController(IBaseService<E, F, V, A, U> service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetPagedResult([FromQuery] F filter)
        {
			var userId = User.GetUserId();
			if (userId == null)
				return Unauthorized();

			var result = await _service.GetPagedResult(filter, userId.Value);
			return Ok(result);
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] int id)
		{
			var result = await _service.Get(id);
			if (!result.Succeed)
				return BadRequest(result.ErrorMessages);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] A model)
        {
			var result = await _service.Add(model);
			if (!result.Succeed)
				return BadRequest(result.ErrorMessages);
			return Ok(result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromBody] U model, [FromRoute] int id)
		{
			var result = await _service.Update(model, id);
			if (!result.Succeed)
				return BadRequest(result.ErrorMessages);
			return Ok(result);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			var result = await _service.Delete(id);
			if (!result.Succeed)
				return BadRequest(result.ErrorMessages);
			return Ok(result);
		}
	}
}

