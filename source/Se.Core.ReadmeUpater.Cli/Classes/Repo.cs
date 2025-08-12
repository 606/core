
namespace Se.Core.ReadmeUpater.Cli.Classes;

    public class Repo
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Visibility { get; set; }
    }
