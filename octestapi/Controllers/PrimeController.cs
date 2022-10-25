using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using octestapi.Models;
using octestapi.Services;

namespace octestapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        private readonly IPrimeNumberService _primeNumberService;
        public PrimeController(IPrimeNumberService primeNumberService)
        {
            _primeNumberService = primeNumberService;
        }

        [HttpGet]
        [Route("is-prime/{number}")]
        public async Task<ActionResult<IsPrimeResultModel>> IsPrime([FromRoute] long number)
        {
            var result = new IsPrimeResultModel();
            result.Result = await _primeNumberService.IsPrime(number);
            return Ok(result);
        }

        [HttpGet]
        [Route("primes/{start}/{end}")]
        public async Task<ActionResult<PrimeNumbersResultModel>> FindPrimes([FromRoute] long start, [FromRoute] long end)
        {
            var result = await _primeNumberService.FindPrimes(start, end);
            return Ok(result);
        }
    }
}
