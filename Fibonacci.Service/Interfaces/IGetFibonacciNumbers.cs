using System.Collections.Generic;
using Fibonacci.Service.Model;

namespace Fibonacci.Service.Interfaces
{
    public interface IGetFibonacciNumbers
    {
        List<int> GetFibonacciNumbers(FibonacciModel model);
    }
}   