using System;

namespace Se.Core.ReadmeUpdater.Cli.Services;

public static class RepoRootLocator
{
    public static string GetRepoRoot()
    {
        var slnPath = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory(), "*.sln")[0];
        return System.IO.Path.GetDirectoryName(slnPath)!;
    }

    public static string GetYamlPath(string[] args)
    {
        var repoRoot = GetRepoRoot();
        return args.Length > 0 ? args[0] : System.IO.Path.Combine(repoRoot, "repos.yaml");
    }

    public static string GetReadmePath(string[] args)
    {
        return args.Length > 1 ? args[1] : "README.md";
    }
}
