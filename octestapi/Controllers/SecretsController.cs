using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace octestapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecretsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("{path}")]
        public ActionResult<string> GetSecret([FromRoute] string path)
        {
            var result = _configuration.GetValue<string>(path);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
