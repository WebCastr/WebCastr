using Microsoft.AspNetCore.Mvc;

namespace WebCaster.API.Controllers
{
    [Route("api/system")]
    [ApiController]
    public class System : ControllerBase
    {
        [HttpGet("ping")]
        public ActionResult<DateTime> Ping()
        {
            return Ok(DateTime.Now.ToUniversalTime());
        }
    }
}
