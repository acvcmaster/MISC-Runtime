using MISCRuntime.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MISCRuntime.Services
{
    public class RuntimeService : IRuntimeService
    {
        private bool Loaded { get; set; } = false;
        public readonly TimeSpan DefaultTimeout = new TimeSpan(0, 0, 5);
        public List<BreakpointModel> Breakpoints = new List<BreakpointModel>();

        public ushort R1 { get; set; } = 0;
        public ushort R2 { get; set; } = 0;
        public ushort R3 { get; set; } = 0;
        public ushort R4 { get; set; } = 0;
        public ushort IP { get; set; } = 0;

        public DebugResponseModel Load(DebugLoadModel model)
        {
            // Assemble file
            // Generate debug symbols (map instruction to line)
            Reset();
            // Load in memory
            Loaded = true;
            return new DebugResponseModel() { Event = string.Empty };
        }

        public async Task<bool> WaitUntilLoaded(TimeSpan timeout)
        {
            var started = DateTime.Now;

            return await Task.Run(() =>
            {
                while (!Loaded)
                {
                    if (DateTime.Now - started > timeout)
                        return false;

                    Thread.Sleep(100);
                }

                return true;
            });
        }

        public void Reset()
        {
            ClearBreakpoints();

            R1 = 0; R2 = 0;
            R3 = 0; R4 = 0;
            IP = 0;

            // stop execution
        }

        public async Task<DebugResponseModel> Start(DebugRequestModel model)
        {
            if (!Loaded)
            {
                if (!await WaitUntilLoaded(DefaultTimeout))
                {
                    Reset();
                    return new DebugResponseModel() { Error = "Load timeout exceeded!" };
                }
            }

            // start
            return new DebugResponseModel() { Event = model.StopOnEntry ? "stopOnEntry" : null };
        }

        public DebugResponseModel Step()
        {
            IP += 4;
            return new DebugResponseModel() { Event = "stopOnStep" };
        }

        public BreakpointModel SetBreakpoint(BreakpointModel model)
        {
            // Check debug symbols (to verify breakpoint)

            // Add breakpoint
            var breakpoint = new BreakpointModel()
            {
                Verified = false,
                Line = model?.Line ?? 0,
                Id = model?.Line ?? 0
            };

            this.Breakpoints.Add(breakpoint);
            return breakpoint;
        }

        public IEnumerable<BreakpointModel> GetBreakpoints()
        {
            return Breakpoints;
        }

        public DebugResponseModel ClearBreakpoints()
        {
            this.Breakpoints.Clear();
            return new DebugResponseModel() { };
        }

        public StrackframesModel GetStackframe()
        {
            return new StrackframesModel()
            {
                Frames = new List<StackframeModel>()
                {
                    new StackframeModel() { Index = 0, Name = $"Address 0x{IP.ToString("X").PadLeft(4, '0')}", Line = IP / 4  }
                },
                Count = 1
            };
        }
        public IEnumerable<VariableModel> GetVariables()
        {
            yield return new VariableModel() { Name = "R1", Value = $"0x{R1.ToString("X")}" };
            yield return new VariableModel() { Name = "R2", Value = $"0x{R2.ToString("X")}" };
            yield return new VariableModel() { Name = "R3", Value = $"0x{R3.ToString("X")}" };
            yield return new VariableModel() { Name = "R4", Value = $"0x{R4.ToString("X")}" };
            yield return new VariableModel() { Name = "IP", Value = $"0x{IP.ToString("X")}" };
            yield break;
        }
    }
}