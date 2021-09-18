using System.Collections.Generic;
using System.Threading.Tasks;
using Fibonacci.Service.Model;

namespace Fibonacci.Service.Interfaces
{
    public interface IGetFibonacciNumbers
    {
        Task<List<int>> GetFibonacciNumbers(FibonacciModel model);
    }
}   