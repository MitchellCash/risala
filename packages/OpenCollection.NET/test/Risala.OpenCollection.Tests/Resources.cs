using System.IO;

namespace Risala.OpenCollection.Tests;

internal static class Resources
{
    /// <summary>
    /// Get the file stream.
    /// </summary>
    /// <param name="fileName">The file name with relative path. For example: "Reader/V1/Samples/OpenCollectionInfo/..".</param>
    /// <returns>The file stream.</returns>
    public static Stream GetStream(string fileName)
    {
        var path = GetPath(fileName);
        var stream = typeof(Resources).Assembly.GetManifestResourceStream(path);

        if (stream == null)
        {
            throw new FileNotFoundException($"The embedded resource '{path}' was not found.", path);
        }

        return stream;
    }

    private static string GetPath(string fileName)
    {
        const string pathSeparator = ".";
        return typeof(Resources).Namespace + pathSeparator + fileName.Replace('/', '.');
    }
}
