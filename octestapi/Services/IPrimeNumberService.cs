using octestapi.Models;

namespace octestapi.Services
{
    public interface IPrimeNumberService
    {
        Task<bool> IsPrime(long number);
        Task<PrimeNumbersResultModel> FindPrimes(long start, long end);
    }
}
