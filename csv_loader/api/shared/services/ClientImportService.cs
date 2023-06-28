﻿using CsvHelper.Configuration;
using CsvHelper;
using Modules.Csv.Infrastructure.Import;
using Modules.User.Application.ImportingClients;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modules.User.Domain;
using Modules.Csv.Abstractions;

namespace Modules.User.Application.shared.services;

public class ClientImportService : IClientImportService
{
    private readonly IClientDataService clientDataService;
    public ClientImportService(IClientDataService clientDataService)
    {
        this.clientDataService = clientDataService;
    }

    public async Task<GetImportResult<ClientList>> Import(string path)
    {
        var errors = new List<string>();

        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ",",
        };

        var clientInfo = await clientDataService.CreateValidClientList(path, csvConfig, errors);
        if (!clientInfo.CorrectList.Any())
        {
            return new GetImportResult<ClientList>(
                new ClientList(new List<Client>()),
                new ImportResult { ErrorsList = errors });
        }

        var clientList = await clientDataService.MapFrom(clientInfo.CorrectList);

        if (clientInfo.ErrorsList.Count == 0)
        {
            return new GetImportResult<ClientList>(clientList, new ImportResult { ErrorsList = errors });
        }

        return new GetImportResult<ClientList>(clientList, new ImportResult { ErrorsList = errors });
    }
}
