using CsvHelper.Configuration;
using Modules.Csv.Abstractions;
using Modules.Csv.Abstractions.Extensions;
using Modules.Csv.Infrastructure;
using Modules.User.Application.ImportingClients;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modules.User.Application.shared.services;

public class ClientDataService : IClientDataService
{
    private readonly ClientDbContext clientDbContext;
    private readonly ICsvService<GetClientInfo> csvService;

    public ClientDataService(ClientDbContext clientDbContext, ICsvService<GetClientInfo> csvService)
    {
        this.clientDbContext = clientDbContext;
        this.csvService = csvService;
    }

    public List<string> ClientValidate(GetClientInfo client)
    {
        var validator = new GetClientInfoValidator();
        var validationResult = validator.Validate(client);

        var errors = new List<string>();
        errors.AddErrors(validationResult);

        return errors;
    }

    public GetClientInfo? Create(GetClientInfo client)
    {
        var clientInfo = new GetClientInfo
        {
            Id = client.Id,
            Name = client.Name,
            Surname = client.Surname,
            Email = client.Email,
            PhoneNumber = client.PhoneNumber,
        };

        return clientInfo;
    }

    public async Task<GetTransferList<GetClientInfo>> CreateValidClientList(string path, CsvConfiguration csvConfig, List<string> errors)
    {
        var validClients = new List<GetClientInfo>();
        var invalidClients = new List<GetClientInfo>();


        var clientsFromFile = await this.csvService.GetRecordsFromCsv<GetClientInfo>(path, csvConfig);

        int rowNumber = 1;

        foreach (var client in clientsFromFile)
        {
            var results = this.ClientValidate(client);

            if (results.Any())
            {
                rowNumber++;
                foreach (string result in results)
                {
                    errors.Add($"row: {rowNumber} | error: {result}");
                }

                invalidClients.Add(client);
                continue;
            }

            var updateClient = this.Create(client);
            validClients.Add(updateClient);
        }

        return new GetTransferList<GetClientInfo> { CorrectList = validClients, ErrorsList = invalidClients };
    }

    public async Task<ClientList> MapFrom(IEnumerable<GetClientInfo> clientToImport)
    {
        var newClients = new List<Client>();
        IEnumerable<GetClientInfo> updatedClientToImport = clientToImport.Skip(1);

        foreach (var client in updatedClientToImport)
        {
            var clientName = client.Name;
            var clientSurname = client.Surname;
            var clientEmail = client.Email;
            var clientPhoneNumber = client.PhoneNumber;

            var newClient = new Client(clientName, clientSurname, clientEmail, clientPhoneNumber);

            newClients.Add(newClient);
        }

        return await Task.FromResult(new ClientList(newClients));
    }
}