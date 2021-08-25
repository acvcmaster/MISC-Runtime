using Microsoft.AspNetCore.Mvc;
using MISCRuntime.Services;
using MISCRuntime.Models;

namespace MISCRuntime.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class DebugController : ControllerBase
    {
        public DebugController(IRuntimeService runtime)
        {
            Runtime = runtime;
        }

        public IRuntimeService Runtime { get; }

        [HttpPost]
        public IActionResult Load(DebugLoadModel model)
        {
            var result = Runtime.Load(model);
            Console.WriteLine("Load");
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Set()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Start([FromBody] DebugRequestModel model)
        {
            var result = await Runtime.Start(model);
            Console.WriteLine("Start");
            Console.WriteLine(result?.Error);
            return Ok(result);
        }
    }
}