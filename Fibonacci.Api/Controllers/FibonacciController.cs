using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fibonacci.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FibonacciController : ControllerBase
    {
        private readonly ILogger<FibonacciController> _logger;

        public FibonacciController(ILogger<FibonacciController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<List<string>> GetFibonacciData()
        {
            return null;
        }
    }
}