using Microsoft.AspNetCore.Mvc;

namespace DaprProjB.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PersonController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger = logger;

    [HttpGet]
    public IActionResult Friend()
    {
        return Ok(new EventSubscriberController.Person { FullName = "Ramin" });
    }
}
