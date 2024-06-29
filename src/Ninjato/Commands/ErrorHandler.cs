using CommandLine;
using Ninjato.Constants;
using Ninjato.Services;

namespace Ninjato.Commands;

public class ErrorHandler : IErrorHandler
{
    private readonly IConsole _console;

    public ErrorHandler(IConsole console)
    {
        _console = console;
    }

    public Task<int> ExecuteAsync(IEnumerable<Error> errors)
    {
        foreach (var error in errors)
        {
            _console.WriteError(error?.ToString()??string.Empty);
        }

        return Task.FromResult(ExitCode.Error);
    }
}