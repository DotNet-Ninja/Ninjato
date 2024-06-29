using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Ninjato.Commands;
using Ninjato.Options;

namespace Ninjato;

class Program
{
    private static readonly IServiceProvider Services = ServiceProviderBuilder.Build();

    static async Task<int> Main(string[] args)
    {
        var exitCode = await Parser.Default.ParseArguments<ScaffoldOptions>(args)
            .MapResult
            (
                async (build) => await Services.GetRequiredService<ICommand<ScaffoldOptions>>().ExecuteAsync(build),
                async (err) => await Services.GetRequiredService<IErrorHandler>().ExecuteAsync(err)
            );

        return exitCode;
    }
}
