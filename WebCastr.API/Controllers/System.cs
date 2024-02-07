using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebCastr.API.Controllers;

[Route("api/system")]
[Tags("System")]
[ApiController]
public class System : ControllerBase
{
    // GET /api/system/ping
    [HttpGet("ping"), AllowAnonymous]
    public ActionResult<DateTime> Ping()
    {
        return Ok(DateTime.Now.ToUniversalTime());
    }
}
