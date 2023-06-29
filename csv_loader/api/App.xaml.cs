using api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Csv.Abstractions;
using Modules.User.Api;
using Modules.User.Application;
using Modules.User.Application.Dependencies;
using Modules.User.Application.shared.services;
using Modules.User.Application.views;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System.IO;
using System.Windows;


namespace api;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider serviceProvider;
    public App()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        serviceProvider = services.BuildServiceProvider();
    }
    private void ConfigureServices(ServiceCollection services)
    {
        services.AddImportModule();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "ProjectConfiguration"))
            .AddJsonFile("appsettings.json")
            .Build();

        services.AddDbContext<ClientDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AppDb")));

        services.AddDbContext<ClientDbContext>(); ;
        services.AddScoped<ClientController>();
        services.AddSingleton<MainWindow>();
        services.AddTransient<FileSelectionWindow>();
        services.AddTransient<EditRecordWindow>();
    }
    protected void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = serviceProvider.GetService<MainWindow>();
        mainWindow.ShowDialog();
    }
}

