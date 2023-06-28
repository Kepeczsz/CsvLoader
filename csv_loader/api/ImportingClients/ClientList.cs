using Modules.User.Domain;
using System.Collections.Generic;

namespace Modules.User.Application.ImportingClients;

public record ClientList(List<Client> listOfClients);