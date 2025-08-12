using System.IO;
using Se.Core.ReadmeUpdater.Cli.Interfaces;

namespace Se.Core.ReadmeUpdater.Cli.Infrastructure;

public class FileWriter : IFileWriter
{
    public void Write(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
