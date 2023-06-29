using Modules.Csv.Abstractions;
using Modules.User.Application.ImportingClients;
using Modules.User.Application.shared;
using Modules.User.Application.shared.services;
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

    public async Task<ClientList> ImportClients(string pathToFile)
    {
        var getImportResult = await this.clientImportService.Import(pathToFile);

        var listOfClients = getImportResult.EntityList;

        var errorList = getImportResult.ImportResult.ErrorsList;

        foreach (var client in listOfClients.listOfClients)
        {
            clientDbContext.Clients.Add(client);

        }
        clientDbContext.SaveChanges();

        return listOfClients;
    }

}