using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCaster.API.Controllers
{
    [Route("api/system")]
    [ApiController]
    public class System : ControllerBase
    {
        [HttpGet("ping")]
        public DateTime Ping()
        {
            return DateTime.Now.ToUniversalTime();
        }
    }
}
