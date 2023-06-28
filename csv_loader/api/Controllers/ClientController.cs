using Modules.User.Application.shared.services;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modules.User.Api;

public class ClientController
{
    private readonly IClientImportService clientImportService;
    private readonly ClientDbContext clientDbContext;

    public ClientController(IClientImportService clientImportService, ClientDbContext clientDbContext)
    {
        this.clientImportService = clientImportService;
        this.clientDbContext = clientDbContext;
    }

    public async Task<List<string>> ImportUsers(string pathToFile)
    {
        var getImportResult = await clientImportService.Import(pathToFile);

        var listOfClients = getImportResult.EntityList;

        var errorList = getImportResult.ImportResult.ErrorsList;

        foreach (var client in listOfClients.listOfClients)
        {
            clientDbContext.Clients.Add(client);
        }

        clientDbContext.SaveChanges();

        return errorList.Any() ? errorList : new List<string>{ "There wasn't any errors" };
    }
}

