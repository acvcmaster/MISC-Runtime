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
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Step()
        {
            var result = Runtime.Step();
            return Ok(result);
        }
    }
}