using System.Diagnostics;
using Ninjato.Constants;
using Ninjato.Options;
using Ninjato.Services;

namespace Ninjato.Commands;

public abstract class CommandBase<TOptions>: ICommand<TOptions> where TOptions: IOptions
{
    protected IConsole Console { get; }

    protected CommandBase(IConsole console)
    {
        Console = console;
    }

    public async Task<int> ExecuteAsync(TOptions options)
    {
        var timer = new Stopwatch();
        timer.Start();
        try
        {
            var result = await OnExecuteAsync(options);
            timer.Stop();
            var elapsed = timer.Elapsed;
            Console.WriteInfo($"Completed in {elapsed}");
            return result;
        }
        catch(Exception ex)
        {
            timer.Stop();
            var time = timer.Elapsed;
            Console.WriteError($"Failed in {time} with error:{Environment.NewLine}{ex.Message}");
            return ExitCode.Error;
        }
    }

    protected abstract Task<int> OnExecuteAsync(TOptions options);
}
