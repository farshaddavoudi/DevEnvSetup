using Microsoft.AspNetCore.Mvc;

namespace DaprProjB.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public PersonController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Friend()
    {
        return Ok(new EventSubscriberController.Person { FullName = "Ramin" });
    }
}
