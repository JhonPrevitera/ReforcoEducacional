using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] 
public class UsersController : ControllerBase
{
	private readonly ILogger<UsersController> _logger;

	public UsersController(ILogger<UsersController> logger)
	{
		_logger = logger;
	}

	[HttpGet] 
	public IActionResult Get()
	{
		_logger.LogInformation("Chamando...");
		return Ok();
	}
	
	
}