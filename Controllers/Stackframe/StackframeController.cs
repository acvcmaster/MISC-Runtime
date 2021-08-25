using Microsoft.AspNetCore.Mvc;
using MISCRuntime.Services;

namespace MISCRuntime.Controllers
{
    [ApiController, Route("[controller]/[action]")]
    public class StackframeController : ControllerBase
    {
        public StackframeController(IRuntimeService runtime)
        {
            Runtime = runtime;
        }

        public IRuntimeService Runtime { get; }

        [HttpGet]
        public IActionResult Get()
        {
            var result = Runtime.GetStackframe();
            return Ok(result);
        }
    }
}