using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using Se.Core.ReadmeUpdater.Cli.Classes;
using Se.Core.ReadmeUpdater.Cli.Interfaces;

namespace Se.Core.ReadmeUpdater.Cli.Infrastructure;

public class YamlRepoReader : IYamlRepoReader
{
    private readonly IDeserializer _deserializer;
    public RepoConfig? Config { get; private set; }

    public YamlRepoReader(IDeserializer deserializer)
    {
        _deserializer = deserializer;
    }

    public Dictionary<string, List<Repo>> ReadRepos(string yamlPath)
    {
        var yamlContent = File.ReadAllText(yamlPath);
        var parser = new YamlDotNet.RepresentationModel.YamlStream();
        using (var reader = new StringReader(yamlContent))
        {
            parser.Load(reader);
        }
        var root = (YamlDotNet.RepresentationModel.YamlMappingNode)parser.Documents[0].RootNode;

        var config = new RepoConfig();
        var categories = new Dictionary<string, List<Repo>>();
        foreach (var entry in root.Children)
        {
            var key = entry.Key.ToString();
            if (key == "config")
            {
                // Парсимо config
                var configNode = (YamlDotNet.RepresentationModel.YamlMappingNode)entry.Value;
                foreach (var c in configNode.Children)
                {
                    var ckey = c.Key.ToString();
                    switch (ckey)
                    {
                        case "profile-name": config.ProfileName = c.Value.ToString(); break;
                        case "github-url": config.GithubUrl = c.Value.ToString(); break;
                        case "repo-url": config.RepoUrl = c.Value.ToString(); break;
                    }
                }
            }
            else
            {
                // Категорії
                var serializer = new YamlDotNet.Serialization.Serializer();
                var yaml = serializer.Serialize(entry.Value);
                var repos = _deserializer.Deserialize<List<Repo>>(new StringReader(yaml));
                categories[key] = repos;
            }
        }
        Config = config;
        return categories;
    }
}
