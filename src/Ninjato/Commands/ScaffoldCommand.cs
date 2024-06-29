using Ninjato.Configuration;
using Ninjato.Constants;
using Ninjato.Models;
using Ninjato.Options;
using Ninjato.Services;

namespace Ninjato.Commands;

public class ScaffoldCommand: CommandBase<ScaffoldOptions>
{
    private readonly IThemeService _themes;

    public ScaffoldCommand(IConsole console, IThemeService themes): base(console)
    {
        _themes = themes;
    }

    protected override Task<int> OnExecuteAsync(ScaffoldOptions options)
    {
        Console.WriteInfo($"Scaffolding site {options.Name}");
        var config = new SiteConfiguration
        {
            Name = options.Name
        };
        _themes.Clone(options, config);

        
        return Task.FromResult(ExitCode.Success);
    }
}