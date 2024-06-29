using Ninjato.Configuration;

namespace Ninjato.Services;

public class SystemConsole: IConsole
{
    private readonly NinjatoSettings _appSettings;

    public SystemConsole(NinjatoSettings appSettings)
    {
        _appSettings = appSettings;
    }

    protected ConsoleSettings Settings => _appSettings.Console;

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void WriteLine(string message, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        WriteLine(message);
        Console.ForegroundColor = previous;
    }

    public void Write(string message)
    {
        Console.Write(message);
    }

    public void Write(string message, ConsoleColor color)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Write(message);
        Console.ForegroundColor = previous;
    }

    public void WriteLine(string template, params object[] args)
    {
        Console.WriteLine(template, args);
    }

    public void WriteLine(string template, ConsoleColor color, params object[] args)
    {
        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        WriteLine(template, args);
        Console.ForegroundColor = previous;
    }

    public void Write(string template, params object[] args)
    {
        Console.Write(template, args);
    }

    public void Write(string template, ConsoleColor color, params object[] args)
    {

        var previous = Console.ForegroundColor;
        Console.ForegroundColor = color;
        WriteLine(template, args);
        Console.ForegroundColor = previous;
    }

    public void WriteInfo(string message)
    {
        WriteLine(message, Settings.InfoColor);
    }

    public void WriteInfo(string template, params object[] args)
    {
        WriteLine(template, Settings.InfoColor, args);
    }

    public void WriteWarning(string message)
    {
        WriteLine(message, Settings.WarningColor);
    }

    public void WriteWarning(string template, params object[] args)
    {
        WriteLine(template, Settings.WarningColor, args);
    }

    public void WriteWarning(Exception ex, string message)
    {
        WriteWarning(ex.Message);
        WriteWarning(message);
    }

    public void WriteWarning(Exception ex, string template, params object[] args)
    {
        WriteWarning(ex.Message);
        WriteWarning(template, args);
    }

    public void WriteError(string message)
    {
        WriteLine(message, Settings.ErrorColor);
    }

    public void WriteError(string template, params object[] args)
    {
        WriteLine(template, Settings.ErrorColor, args);
    }

    public void WriteError(Exception ex, string message)
    {
        WriteError(ex.Message);
        WriteError(message);
    }

    public void WriteError(Exception ex, string template, params object[] args)
    {
        WriteError(ex.Message);
        WriteWarning(template, args);
    }
}