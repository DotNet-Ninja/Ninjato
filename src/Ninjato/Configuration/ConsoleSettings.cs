namespace Ninjato.Configuration;

public class ConsoleSettings
{
    public ConsoleColor DefaultColor { get; set; } = ConsoleColor.Gray;
    public ConsoleColor InfoColor { get; set; } = ConsoleColor.Cyan;
    public ConsoleColor WarningColor { get; set; } = ConsoleColor.Yellow;
    public ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;
}