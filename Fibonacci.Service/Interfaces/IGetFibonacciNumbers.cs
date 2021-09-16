using System.Collections.Generic;

namespace Fibonacci.Service.Interfaces
{
    public interface IGetFibonacciNumbers
    {
        List<int> GetFibonacciNumbers(FibonacciModel model);
    }
}   