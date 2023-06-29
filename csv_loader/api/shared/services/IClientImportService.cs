using System.Threading.Tasks;
using Modules.Csv.Infrastructure.Import;
using Modules.User.Application.ImportingClients;

namespace Modules.User.Application.shared.services;

public interface IClientImportService
{
    /// <summary>
    /// Imports client data from the provided path to file.
    /// </summary>
    /// <param name="path">The path to file containing the user data to import.</param>
    /// <returns>A <see cref="Task{TResult}"/>Representing the result of the asynchronous operation.</returns>
    Task<GetImportResult<ClientList>> Import(string path);
}

