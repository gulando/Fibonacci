using System.Threading.Tasks;
using AutoMapper;
using Fibonacci.Api.Filters;
using Fibonacci.Api.RequestModels;
using Fibonacci.Service.Interfaces;
using Fibonacci.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fibonacci.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FibonacciController : ControllerBase
    {
        private readonly IGetFibonacciNumbers _fibonacci;
        private readonly ILogger<FibonacciController> _logger;
        private readonly IMapper _mapper;

        public FibonacciController(ILogger<FibonacciController> logger, IGetFibonacciNumbers fibonacci, IMapper mapper)
        {
            _logger = logger;
            _fibonacci = fibonacci;
            _mapper = mapper;
        }

        [HttpGet]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<string> GetFibonacciData([FromQuery] FibonacciRequestModel model)
        {
            _logger.LogInformation($"{nameof(FibonacciController)} - {nameof(GetFibonacciData)}");

            var requestData = _mapper.Map<FibonacciModel>(model);
            var data = await _fibonacci.GetFibonacciNumbers(requestData);
            
            return JsonConvert.SerializeObject(data);
        }
    }
}