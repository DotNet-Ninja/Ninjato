using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ninjato.Configuration;

public class NinjatoSettings
{
    public static readonly string DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ninjato");
    public static readonly string FilePath = Path.Combine(DirectoryPath, "settings.json");
    public static readonly string ThemePath = Path.Combine(DirectoryPath, "themes");

    public ConsoleSettings Console { get; set; } = new ConsoleSettings();

    public string Serialize()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() }});
    }
}