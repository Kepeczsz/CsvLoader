using CsvHelper.Configuration;
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
    private readonly ICsvService<GetClientInfo> csvService;

    public ClientImportService(ICsvService<GetClientInfo> csvService)
    {
        this.csvService = csvService;
    }

    public async Task<GetImportResult<ClientList>> Import(string path)
    {
        var errors = new List<string>();

        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            Delimiter = ",",
        };


        //if (clientInfo.CorrectList.Count == 0)
        //{
        //    return new GetImportResult<ClientList>(
        //        new ClientList(new List<Client>()),
        //        new ImportResult { ErrorsList = errors });
        //}


        //var budgetsAggregateList = await this.budgetDataService.MapFrom(budgetInfos.CorrectList);

        //if (clientInfo.ErrorsList.Count == 0)
        //{
        //    return new GetImportResult<ClientList>(budgetsAggregateList, new ImportResult { ErrorsList = errors });
        //}

        return new GetImportResult<ClientList>(null, new ImportResult { ErrorsList = errors });
    }
}

