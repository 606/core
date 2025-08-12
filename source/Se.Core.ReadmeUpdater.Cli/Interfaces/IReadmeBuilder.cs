using System.Collections.Generic;
using Se.Core.ReadmeUpdater.Cli.Classes;

namespace Se.Core.ReadmeUpdater.Cli.Interfaces;

public interface IReadmeBuilder
{
    string Build(Dictionary<string, List<Repo>> categories, RepoConfig? config);
}
