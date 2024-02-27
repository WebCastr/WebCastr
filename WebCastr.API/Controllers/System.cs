using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebCastr.API.Controllers;

[Route("/system")]
[Tags("System")]
[ApiController]
public class System : ControllerBase
{
    /// <summary>
    /// Get a simple status response about the state of WebCastr
    /// </summary>
    /// <returns>The current UTC date and time on the server</returns>
    // GET /system/ping
    [HttpGet("ping"), AllowAnonymous]
    public ActionResult<DateTime> Ping()
    {
        return Ok(DateTime.Now.ToUniversalTime());
    }
}
