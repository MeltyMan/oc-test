using octestapi.Models;
using System.Diagnostics;

namespace octestapi.Services
{
    public class PrimeNumberService : IPrimeNumberService
    {
        public async Task<PrimeNumbersResultModel> FindPrimes(long start, long end)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result = new PrimeNumbersResultModel();
            var counter = 0;

            for (var n = start; n <= end; n++)
            {
                var isPrime = await IsPrime(n);
                if (isPrime)
                {
                    counter++;

                }
            }
            stopWatch.Stop();
            result.ExecutionTime = stopWatch.ElapsedMilliseconds;
            result.Count = counter;

            return await Task.FromResult(result);
        }

        public async Task<bool> IsPrime(long number)
        {
            var result = true;
            if (number <= 1)
            {
                return await Task.FromResult(false);
            }
            if (number == 3)
            {
                return await Task.FromResult(true);
            }
            if (number % 2 == 0 || number % 3 == 0)
            {
                return await Task.FromResult(false);
            }

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    result = false;
                    break;
                }
            }

            return await Task.FromResult(result);
        }
    }
}
