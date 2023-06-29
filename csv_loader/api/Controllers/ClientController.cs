using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Modules.Csv.Abstractions;
using Modules.Csv.Infrastructure;
using Modules.User.Application.shared;
using Modules.User.Application.shared.services;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Modules.User.Api;

public class ClientController
{
    private readonly IClientImportService clientImportService;
    private readonly ICsvService<GetClientInfo> csvService;
    private readonly ClientDbContext clientDbContext;

    public ClientController(IClientImportService clientImportService, ClientDbContext clientDbContext, ICsvService<GetClientInfo> csvService)
    {
        this.clientImportService = clientImportService;
        this.clientDbContext = clientDbContext;
        this.csvService = csvService;
    }

    public async Task<List<string>> ImportClients(string pathToFile)
    {
        var getImportResult = await this.clientImportService.Import(pathToFile);

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