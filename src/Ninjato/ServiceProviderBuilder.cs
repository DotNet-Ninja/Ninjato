using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ninjato.Commands;
using Ninjato.Configuration;
using Ninjato.Options;
using Ninjato.Services;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO.Abstractions;


namespace Ninjato;

public static class ServiceProviderBuilder
{
    public static IServiceProvider Build()
    {
        var settings = new NinjatoSettings();
        var services = new ServiceCollection();

        var config = new ConfigurationBuilder()
            .AddJsonFile(NinjatoSettings.FilePath, optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        config.Bind(settings);

        var serializerFactory = (new SerializerBuilder()).WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        var deserializerFactory = (new DeserializerBuilder()).WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
        var serializer = new YamlObjectSerializer(serializerFactory, deserializerFactory);

        var fileSystem = new FileSystem();

        services.AddSingleton(settings)
                .AddSingleton<IObjectSerializer>(serializer)
                .AddSingleton<IFileSystem>(fileSystem)
                .AddSingleton<IConsole, SystemConsole>()
                .AddSingleton<ITimeProvider, SystemTimeProvider>()
                .AddSingleton<IErrorHandler,ErrorHandler>()
                .AddSingleton<ICommand<ScaffoldOptions>, ScaffoldCommand>()
                .AddSingleton<IThemeService, ThemeService>();

        return services.BuildServiceProvider();
    }
}