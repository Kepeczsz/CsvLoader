using api;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.projectConfiguration;
using Modules.User.Application.views;
using System.Windows;
using System.Windows.Input;

namespace Modules.User.Application.ViewModel;

public class MainViewModel
{
    public MainViewModel()
    {
        OpenLoadView = new RelayCommand(Load_FileSelectionWindow_Click, CanChangeView);
    }
    public ICommand OpenLoadView { get; set; }

    private void Load_FileSelectionWindow_Click(object sender)
    {
        FileSelectionWindow fileSelectionWindow = App.serviceProvider.GetRequiredService<FileSelectionWindow>();
        fileSelectionWindow.Show();
    }

    private bool CanChangeView(object sender)
    {
        return true;
    }
}