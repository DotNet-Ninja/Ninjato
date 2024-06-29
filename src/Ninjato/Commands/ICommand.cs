using Ninjato.Options;

namespace Ninjato.Commands;

public interface ICommand<in TOptions> where TOptions : IOptions
{
    Task<int> ExecuteAsync(TOptions options);
}