using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Dtos;
using UserService.Application.Interfaces;

namespace UserService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class UsersController(ILogger<UsersController> logger, IUserService userAppService) : ControllerBase
{
	[HttpGet] 
	public IActionResult Get()
	{
		logger.LogInformation("Chamando...");
		return Ok();
	}
	
	
	[HttpPost("parent/create")]
	public async Task<IActionResult> CreateParentWithChildren([FromBody] CreateParentRequest dto)
	{
		var user = await userAppService.CreateParentWithChildrenAsync(dto);
		return Ok(user);
	}
}