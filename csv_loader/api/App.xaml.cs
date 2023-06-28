using api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modules.Csv.Abstractions;
using Modules.User.Api;
using Modules.User.Application.Dependencies;
using Modules.User.Application.shared.services;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
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
        services.AddDbContext<ClientDbContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=Clients; Trusted_Connection=True;MultipleActiveResultSets=true")); ;
        services.AddScoped<ClientController>();
        services.AddSingleton<MainWindow>();
    }
    protected void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}

