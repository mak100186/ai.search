namespace AI.Search.Helpers;

using System.Reflection;

public static class PathHelper
{
    public static string? AssemblyDirectory
    {
        get
        {
            var codeBase = Assembly.GetExecutingAssembly().Location;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}