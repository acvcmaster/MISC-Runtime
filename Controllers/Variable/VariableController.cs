using Microsoft.AspNetCore.Mvc;
using MISCRuntime.Services;

namespace MISCRuntime.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class VariableController : ControllerBase
    {
        public VariableController(IRuntimeService runtime)
        {
            Runtime = runtime;
        }

        public IRuntimeService Runtime { get; }

        [HttpGet]
        public IActionResult Get()
        {
            var result = Runtime.GetVariables();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Set()
        {
            return Ok();
        }
    }
}