using MISCRuntime.Models;

namespace MISCRuntime.Services
{
    public interface IRuntimeService
    {
        DebugResponseModel Load(DebugLoadModel model);
        Task<DebugResponseModel> Start(DebugRequestModel model);
        DebugResponseModel Step();
        void Reset();
        BreakpointModel SetBreakpoint(BreakpointModel model);
        IEnumerable<BreakpointModel> GetBreakpoints();
        DebugResponseModel ClearBreakpoints();
        StrackframesModel GetStackframe();
        IEnumerable<VariableModel> GetVariables();
    }
}