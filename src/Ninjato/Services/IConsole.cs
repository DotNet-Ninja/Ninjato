namespace Ninjato.Services;

public interface IConsole
{
    void WriteLine(string message);
    void WriteLine(string message, ConsoleColor color);
    void Write(string message);
    void Write(string message, ConsoleColor color);

    void WriteLine(string template, params object[] args);
    void WriteLine(string template, ConsoleColor color, params object[] args);
    void Write(string template, params object[] args);
    void Write(string template, ConsoleColor color, params object[] args);

    void WriteInfo(string message);
    void WriteInfo(string template, params object[] args);

    void WriteWarning(string message);
    void WriteWarning(string template, params object[] args);
    void WriteWarning(Exception ex, string message);
    void WriteWarning(Exception ex, string template, params object[] args);

    void WriteError(string message);
    void WriteError(string template, params object[] args);
    void WriteError(Exception ex, string message);
    void WriteError(Exception ex, string template, params object[] args);
}