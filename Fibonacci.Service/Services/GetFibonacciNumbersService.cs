using System.Collections.Generic;
using Fibonacci.Service.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Fibonacci.Service.Services
{
    public class GetFibonacciNumbersService : IGetFibonacciNumbers
    {
        private IMemoryCache _cache;

        public GetFibonacciNumbersService(IMemoryCache cache)
        {
            _cache = cache;
        }
        
        public List<int> GetFibonacciNumbers(FibonacciModel model)
        {
            var numbers = new List<int>();

            if (model.UseCache)
            {
                if (_cache.TryGetValue($"{model.StartIndex}-{model.EndIndex}", out numbers))
                {
                    return numbers;
                }
            }
            

            for (var i = model.StartIndex; i < model.EndIndex; i++)
            {
                numbers.Add(Fibonacci(i));
            }

            _cache.Set($"{model.StartIndex}-{model.EndIndex}", numbers);
            return numbers;
        }
        
        private static int Fibonacci(int n)
        {
            var a = 0;
            var b = 1;
            
            for (var i = 0; i < n; i++)
            {
                var temp = a;
                a = b;
                b = temp + b;
            }
            
            return a;
        }
    }
}