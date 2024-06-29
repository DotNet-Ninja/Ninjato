using CommandLine;

namespace Ninjato.Commands;

public interface IErrorHandler
{
    Task<int> ExecuteAsync(IEnumerable<Error> errors);
}