using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebCaster.API.Controllers;

[Route("api/system")]
[Tags("System")]
[ApiController]
public class System : ControllerBase
{
    [HttpGet("ping"), AllowAnonymous]
    public ActionResult<DateTime> Ping()
    {
        return Ok(DateTime.Now.ToUniversalTime());
    }
}
