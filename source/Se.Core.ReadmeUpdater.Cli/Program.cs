
using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Se.Core.ReadmeUpdater.Cli.Interfaces;
using Se.Core.ReadmeUpdater.Cli.Infrastructure;
using Se.Core.ReadmeUpdater.Cli.Services;

namespace Se.Core.ReadmeUpdater.Cli;

static class Program
{
	static void Main(string[] args)
	{
		var deserializer = new DeserializerBuilder()
			.WithNamingConvention(CamelCaseNamingConvention.Instance)
			.Build();
		IYamlRepoReader repoReader = new YamlRepoReader(deserializer);
		IReadmeBuilder readmeBuilder = new MarkdownReadmeBuilder();
		IFileWriter fileWriter = new FileWriter();
	var updater = new Services.ReadmeUpdater(repoReader, readmeBuilder, fileWriter);


		var yamlPath = RepoRootLocator.GetYamlPath(args);
		var readmePath = RepoRootLocator.GetReadmePath(args);


	FileValidator.EnsureFileExists(yamlPath, "repos.yaml not found");

		updater.Update(yamlPath, readmePath);
		Console.WriteLine($"README generated from {yamlPath} to {readmePath}");
	}
}
