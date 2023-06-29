using Microsoft.Extensions.DependencyInjection;
using Modules.Csv.Abstractions;
using Modules.Csv.Infrastructure;
using Modules.User.Application.Shared;
using Modules.User.Application.Shared.Services;

namespace Modules.User.Application.Dependencies;
public static class ImportModule
{
    /// <summary>
    /// Add module services.
    /// </summary>
    /// <param name="services">IServiceCollection.</param>
    /// <returns>Updated IServiceCollection.</returns>
    public static IServiceCollection AddImportModule(this IServiceCollection services)
    {
        services.AddScoped<IClientImportService, ClientImportService>();
        services.AddScoped<IClientDataService, ClientDataService>();
        services.AddScoped<ICsvService<GetClientInfo>, CsvService<GetClientInfo>>();

        return services;
    }
}
