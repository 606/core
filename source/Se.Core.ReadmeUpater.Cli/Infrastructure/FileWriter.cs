using System.IO;
using Se.Core.ReadmeUpater.Cli.Interfaces;

namespace Se.Core.ReadmeUpater.Cli.Infrastructure;

public class FileWriter : IFileWriter
{
    public void Write(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
