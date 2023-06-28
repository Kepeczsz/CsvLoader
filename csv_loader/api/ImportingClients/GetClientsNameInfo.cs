using System.Collections.Generic;

namespace Modules.User.Application.ImportingClients;
/// <summary>
///  The record is used to store information about the names of clients.
/// </summary>
public record GetClientsNameInfo
{
    public List<string>? ClientNames { get; init; }
}

