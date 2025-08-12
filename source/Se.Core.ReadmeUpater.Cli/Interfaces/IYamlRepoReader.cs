using System.Collections.Generic;
using Se.Core.ReadmeUpater.Cli.Classes;

namespace Se.Core.ReadmeUpater.Cli.Interfaces;

public interface IYamlRepoReader
{
    Dictionary<string, List<Repo>> ReadRepos(string yamlPath);
}
