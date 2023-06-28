using System.Threading.Tasks;
using Modules.Csv.Infrastructure.Import;
using Modules.User.Application.ImportingClients;
using Modules.User.Domain;

namespace Modules.User.Application.shared.services;

public interface IClientImportService
{
    /// <summary>
    /// Imports budget data from the provided file.
    /// </summary>
    /// <param name="path">The path to file containing the user data to import.</param>
    /// <returns>A <see cref="Task{TResult}"/>Representing the result of the asynchronous operation.</returns>
    Task<GetImportResult<ClientList>> Import(string path);
}

