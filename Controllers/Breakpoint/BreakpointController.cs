using Microsoft.AspNetCore.Mvc;
using MISCRuntime.Models;
using MISCRuntime.Services;

namespace MISCRuntime.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class BreakpointController : ControllerBase
    {
        public BreakpointController(IRuntimeService runtime)
        {
            Runtime = runtime;
        }

        public IRuntimeService Runtime { get; }

        [HttpGet]
        public IActionResult Get()
        {
            var result = Runtime.GetBreakpoints();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Set(BreakpointModel model)
        {
            var result = Runtime.SetBreakpoint(model);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult Clear()
        {
            var result = Runtime.ClearBreakpoints();
            return Ok(result);
        }
    }
}