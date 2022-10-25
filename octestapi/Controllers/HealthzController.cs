using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace octestapi.Controllers
{
    [Route("healthz")]
    [ApiController]
    public class HealthzController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<string> HealthCheck()
        {
            return Ok("I am here!");
        }
    }
}
