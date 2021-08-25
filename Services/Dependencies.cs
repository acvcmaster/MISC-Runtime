namespace MISCRuntime.Services
{
    public static class DependencyResolver
    {
        public static void ResolveDependencies(WebApplicationBuilder? builder)
        {
            builder?.Services.AddSingleton<IRuntimeService, RuntimeService>();
            builder?.Services.AddSingleton<IAssemblerService, AssemblerService>();
        }
    }
}
