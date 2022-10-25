using Microsoft.AspNetCore.Mvc;

namespace octestapi.Controllers;
[ApiController]
[Route("hello")]

public class KalleController : ControllerBase
{
    [HttpGet]
    [Route("")]
    public ActionResult<string> Hello([FromQuery] string? name)
    {
        var result = "Hello";
        if (!string.IsNullOrEmpty(name))
        {
            result = $"{result} {name}";
        }

        result = $"{result}!";
        
        return Ok(result);
    }
}