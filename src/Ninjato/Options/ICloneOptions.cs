using CommandLine;

namespace Ninjato.Options;

public interface ICloneOptions
{
    public string Name { get; }

    public string Theme { get; }

    public bool Force { get; }

    public string ResolvedOutput { get; }
}