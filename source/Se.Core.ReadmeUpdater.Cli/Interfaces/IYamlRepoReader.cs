using System.Collections.Generic;
using Se.Core.ReadmeUpdater.Cli.Classes;

namespace Se.Core.ReadmeUpdater.Cli.Interfaces;

public interface IYamlRepoReader
{
    Dictionary<string, List<Repo>> ReadRepos(string yamlPath);
}
