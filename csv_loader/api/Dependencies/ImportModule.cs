using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Csv.Abstractions;
using Modules.Csv.Infrastructure;
using Modules.User.Application.shared;
using Modules.User.Application.shared.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Dependencies;
public static class ImportModule
{
    /// <summary>
    /// Add module services.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <param name="configurationManager">ConfigurationManager.</param>
    /// <returns>Updated IServiceCollection.</returns>
    public static IServiceCollection AddImportModule(this IServiceCollection services)
    {
        services.AddScoped<IClientImportService, ClientImportService>();
        services.AddScoped<IClientDataService, ClientDataService>();
        services.AddScoped<ICsvService<GetClientInfo>, CsvService<GetClientInfo>>();

        return services;
    }
}
