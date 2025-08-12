using Se.Core.ReadmeUpater.Cli.Interfaces;
using System.Collections.Generic;
using Se.Core.ReadmeUpater.Cli.Classes;

namespace Se.Core.ReadmeUpater.Cli.Services;

public class ReadmeUpdater
{
    private readonly IYamlRepoReader _repoReader;
    private readonly IReadmeBuilder _readmeBuilder;
    private readonly IFileWriter _fileWriter;

    public ReadmeUpdater(IYamlRepoReader repoReader, IReadmeBuilder readmeBuilder, IFileWriter fileWriter)
    {
        _repoReader = repoReader;
        _readmeBuilder = readmeBuilder;
        _fileWriter = fileWriter;
    }

    public void Update(string yamlPath, string readmePath)
    {
        var categories = _repoReader.ReadRepos(yamlPath);
        var config = (_repoReader as Infrastructure.YamlRepoReader)?.Config;
        var readmeContent = _readmeBuilder.Build(categories, config);
        _fileWriter.Write(readmePath, readmeContent);
    }
}
