using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Fibonacci.Service.Interfaces;
using Fibonacci.Service.Model;
using Microsoft.Extensions.Caching.Memory;

namespace Fibonacci.Service.Services
{
    public class GetFibonacciNumbersService : IGetFibonacciNumbers
    {
        private readonly IMemoryCache _cache;
        private readonly CacheItemPolicy _cacheItemPolicy;

        public GetFibonacciNumbersService(IMemoryCache cache)
        {
            _cache = cache;

            _cacheItemPolicy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(30)
            };
        }

        public List<int> GetFibonacciNumbers(FibonacciModel model)
        {
            if (model.UseCache)
            {
                if (_cache.TryGetValue($"{model.StartIndex}-{model.EndIndex}", out List<int> cashedNumbers))
                {
                    return cashedNumbers;
                }
            }
            
            var numbers = new List<int>();
            for (var i = model.StartIndex; i < model.EndIndex; i++)
            {
                numbers.Add(Fibonacci(i));
            }

            _cache.Set($"{model.StartIndex}-{model.EndIndex}", numbers, _cacheItemPolicy.AbsoluteExpiration);
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