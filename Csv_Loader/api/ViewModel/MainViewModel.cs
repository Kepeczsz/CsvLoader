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
        OpenLoadView = new RelayCommand(ChangeViewToFileSelection, CanExecute);
    }
    public ICommand OpenLoadView { get; set; }

    private void ChangeViewToFileSelection(object sender)
    {
        FileSelectionWindow fileSelectionWindow = App.serviceProvider.GetRequiredService<FileSelectionWindow>();
        fileSelectionWindow.Show();
    }

    private bool CanExecute(object sender)
    {
        return true;
    }
}