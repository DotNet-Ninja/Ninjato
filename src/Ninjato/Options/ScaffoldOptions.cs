using CommandLine;

namespace Ninjato.Options;

[Verb("scaffold", HelpText = "Scaffold a new site.")]
public class ScaffoldOptions: IOptions, ICloneOptions
{
    private string? _output = null;

    [Option('n', "Name", Required = true, HelpText = "The name site to scaffold.")]
    public string Name { get; set; } = string.Empty;

    [Option('t', "Theme", Required = false, HelpText = "The Ninjato theme for the new site.")]
    public string Theme { get; set; } = "default";

    [Option('o', "Output", Required = false, HelpText = "The output directory for the new site.")]
    public string Output
    {
        get => _output ?? Name;
        set => _output = value;
    }

    [Option('f', "Force", Required = false, Default = false, HelpText = "Force the scaffolder to overwrite existing files.")]
    public bool Force { get; set; } = false;

    public string ResolvedOutput => Path.GetFullPath(Output);


}