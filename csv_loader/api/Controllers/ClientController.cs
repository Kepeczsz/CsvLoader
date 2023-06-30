using Modules.User.Application.ImportingClients;
using Modules.User.Application.Shared.Services;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Modules.User.Application.Controllers;

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

    public async void ChangeClientData(Client client)
    {
        var clientExists = clientDbContext.Clients.FirstOrDefault(c => c.Id == client.Id);

        var validator = new GetClientValidator();

        if (clientExists != null)
        {
            var validationResult = validator.Validate(client);

            if (validationResult.IsValid)
            {
                MessageBox.Show("Client changed succesfully");

                clientExists.Name = client.Name;
                clientExists.Surname = client.Surname;
                clientExists.Email = client.Email;
                clientExists.PhoneNumber = client.PhoneNumber;

                clientDbContext.SaveChanges();
            }
            else
            {
                StringBuilder errorList = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    errorList.Append(error.ErrorMessage).Append(" ");
                }
                MessageBox.Show(errorList.ToString());
            }
        }
    }
}