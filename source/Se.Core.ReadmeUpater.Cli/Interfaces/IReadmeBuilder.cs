using System.Collections.Generic;
using Se.Core.ReadmeUpater.Cli.Classes;

namespace Se.Core.ReadmeUpater.Cli.Interfaces;

public interface IReadmeBuilder
{
    string Build(Dictionary<string, List<Repo>> categories, RepoConfig? config);
}
