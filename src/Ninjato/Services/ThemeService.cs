using System.IO.Abstractions;
using Ninjato.Configuration;
using Ninjato.Constants;
using Ninjato.Models;
using Ninjato.Options;

namespace Ninjato.Services;

public class ThemeService : IThemeService
{
    private readonly IFileSystem _fileSystem;
    private readonly IConsole _console;
    private readonly IObjectSerializer _serializer;

    public ThemeService(IFileSystem fileSystem, IConsole console, IObjectSerializer serializer)
    {
        _fileSystem = fileSystem;
        _console = console;
        _serializer = serializer;
    }

    public bool Clone(ICloneOptions options, SiteConfiguration configuration)
    {
        if(options.Force)
        {
            _console.WriteInfo("Force option enabled, overwriting existing files.");
        }

        string sourcePath = Path.Combine(NinjatoSettings.ThemePath, options.Theme);
        if(!_fileSystem.Directory.Exists(sourcePath))
        {
            _console.WriteError($"Theme {options.Name} not found.");
            return false;
        }
        CopyDirectory(options.ResolvedOutput, sourcePath, options.ResolvedOutput, options.Force);

        var configPath = Path.Combine(options.ResolvedOutput, FileName.SiteConfig);
        if (!_fileSystem.File.Exists(configPath) || options.Force)
        {
            _console.WriteInfo($"Creating {FileName.SiteConfig}");
            var configContent = _serializer.Serialize(configuration);
            _fileSystem.File.WriteAllText(configPath, configContent);
        }
        else
        {
            _console.WriteWarning($"Skipping File {FileName.SiteConfig} - it already exists.");
        }
        return true;
    }

    private void CopyDirectory(string rootPath, string sourcePath, string destinationPath, bool force)
    {
        if(!_fileSystem.Directory.Exists(destinationPath))
        {
            _fileSystem.Directory.CreateDirectory(destinationPath);
        }

        foreach (var file in _fileSystem.Directory.GetFiles(sourcePath))
        {
            var destinationFile = Path.Combine(destinationPath, _fileSystem.Path.GetFileName(file));
            var relativeDestination= _fileSystem.Path.GetRelativePath(rootPath, destinationFile);
            if(!_fileSystem.File.Exists(destinationFile) || force)
            {
                _console.WriteInfo($"Creating {relativeDestination}");
                _fileSystem.File.Copy(file, destinationFile, force);
            }
            else
            {
                _console.WriteWarning($"Skipping File {relativeDestination} - it already exists.");
            }
        }

        foreach (var directory in _fileSystem.Directory.GetDirectories(sourcePath))
        {
            var destinationDirectory = Path.Combine(destinationPath, _fileSystem.Path.GetFileName(directory));
            CopyDirectory(rootPath, directory, destinationDirectory, force);
        }
    }
}