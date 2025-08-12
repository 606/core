using System.Collections.Generic;
using System.Text;
using Se.Core.ReadmeUpater.Cli.Classes;
using Se.Core.ReadmeUpater.Cli.Interfaces;

namespace Se.Core.ReadmeUpater.Cli.Infrastructure;

public class MarkdownReadmeBuilder : IReadmeBuilder
{
    public string Build(Dictionary<string, List<Repo>> categories, RepoConfig? config)
    {
        var sb = new StringBuilder();
        sb.AppendLine("# Core Repository - Project Index\n");
    // (Profile, GitHub, Repo URL section removed)
        sb.AppendLine("This repository contains indexes for multiple project repositories grouped by category.\n");
        foreach (var category in categories)
        {
            sb.AppendLine($"## {category.Key}\n");
            foreach (var repo in category.Value)
            {
                var url = repo.Url;
                if (string.IsNullOrEmpty(url) && config != null && !string.IsNullOrEmpty(config.RepoUrl))
                {
                    url = config.RepoUrl.Replace("{repo}", repo.Name);
                }
                sb.AppendLine($"- [{repo.Name}]({url}) - {repo.Description}");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
