namespace MISCRuntime.Models
{
    public class StackframeModel
    {
        public int Index { get; set; }
        public string? Name { get; set; }
        public string? File { get; set; }
        public int Line { get; set; }
    }

    public class StrackframesModel
    {
        public IEnumerable<StackframeModel>? Frames { get; set; }
        public int Count { get; set; }
    }
}