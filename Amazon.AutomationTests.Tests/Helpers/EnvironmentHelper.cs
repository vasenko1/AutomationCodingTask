namespace Amazon.AutomationTests.Tests.Helpers
{
    public static class EnvironmentHelper
    {
        private static string? _assemblyDirectory;
        public static string AssemblyDirectory
        {
            get
            {
                if (string.IsNullOrEmpty(_assemblyDirectory))
                {
                    System.Reflection.Assembly? assembly = System.Reflection.Assembly.GetEntryAssembly();
                    if (assembly == null)
                    {
                        assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    }
                    _assemblyDirectory = Path.GetDirectoryName(assembly.Location) + Path.DirectorySeparatorChar;
                }
                return _assemblyDirectory;
            }
        }
    }
}
