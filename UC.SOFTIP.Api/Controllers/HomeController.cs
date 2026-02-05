using Microsoft.AspNetCore.Mvc;

namespace UC.SOFTIP.Api.Controllers;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(new
        {
            message = "Welcome to UC.SOFTIP API",
            version = "1.0.0",
            status = "Running",
            endpoints = new[]
            {
                "/api/weatherforecast - Get weather forecast data"
            }
        });
    }
}
