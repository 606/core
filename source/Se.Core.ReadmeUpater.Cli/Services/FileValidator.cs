using System;

namespace Se.Core.ReadmeUpater.Cli.Services;

public static class FileValidator
{
    public static void EnsureFileExists(string path, string errorMessage)
    {
        if (!System.IO.File.Exists(path))
        {
            Console.Error.WriteLine($"[ERROR] {errorMessage} at '{path}'");
            Environment.Exit(1);
        }
    }
}
