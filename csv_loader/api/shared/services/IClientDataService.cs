using CsvHelper.Configuration;
using Modules.Csv.Infrastructure;
using Modules.User.Application.ImportingClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.shared.services;

public interface IClientDataService
{
    /// <summary>
	/// Converts a collection of client information from CSV format into a list of client objects.
	/// </summary>
	/// <param name="clientToImport">Collection of budget information to be converted, represented as GetBudgetTransferInfo objects.</param>
	/// <returns>A Task containing a BudgetAggregateList, representing the converted budget information.</returns>
	Task<ClientList> MapFrom(IEnumerable<GetClientInfo> clientToImport);

    /// <summary>
    /// Creates a new client based on the provided client's information.
    /// If a client with the same name already exists in the database, a random number is appended to the name.
    /// </summary>
    /// <param name="client">The client information used to create the new client.</param>
    /// <returns>Creates a new budget.</returns>
    public GetClientInfo? Create(GetClientInfo client);

    /// <summary>
    /// Validates the properties of a client object.
    /// </summary>
    /// <param name="client">The client object to validate.</param>
    /// <returns>A list of error messages. If the list is empty, the budget object is valid.</returns>
    public List<string> ClientValidate(GetClientInfo client);

    /// <summary>
    /// Reads clients from a CSV file, validates them, and returns a list of valid clients.
    /// Any errors encountered during validation are added to the provided errors list.
    /// </summary>
    /// <param name="path">The CSV file path containing the clients to be read and validated.</param>
    /// <param name="csvConfig">Configuration for reading the CSV file.</param>
    /// <param name="errors">A list to which any validation errors will be added.</param>
    /// <returns>A list of valid clients read from the CSV file.</returns>
    public Task<GetTransferList<GetClientInfo>> CreateValidClientList(string path, CsvConfiguration csvConfig, List<string> errors);
}