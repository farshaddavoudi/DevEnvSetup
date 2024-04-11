using DaprProjB.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DaprProjB.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PersonController() : ControllerBase
{
    [AllowAnonymous]
    [DaprAuthorize]
    [HttpGet]
    public IActionResult Friend()
    {
        return Ok(new EventSubscriberController.Person { FullName = "Ramin" });
    }
}
