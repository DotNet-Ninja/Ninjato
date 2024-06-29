using Ninjato.Models;
using Ninjato.Options;

namespace Ninjato.Services;

public interface IThemeService
{
    bool Clone(ICloneOptions options, SiteConfiguration configuration);
}