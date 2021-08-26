namespace MISCRuntime
{
    public class VariableModel
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string Type { get; set; } = "integer";
        public int VariablesRerence { get; set; } = 0;
        public string? EvaluateName => Name != null ? $"${Name}" : null;
        public string __vscodeVariableMenuContext = "simple";
    }
}