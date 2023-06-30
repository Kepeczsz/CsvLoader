using api;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.views;
using System.Windows;

namespace Modules.User.Application.ViewModel;

public class MainViewModel
{
    public MainViewModel()
    {
    }

    private void Load_FileSelectionWindow_Click(object sender, RoutedEventArgs e)
    {
        FileSelectionWindow fileSelectionWindow = App.serviceProvider.GetRequiredService<FileSelectionWindow>();
        fileSelectionWindow.Show();
    }
}