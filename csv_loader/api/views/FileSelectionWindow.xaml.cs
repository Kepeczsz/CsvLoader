using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using Modules.User.Application.Controllers;
using Modules.User.Application.ImportingClients;
using Modules.User.Application.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Modules.User.Application.views;

public partial class FileSelectionWindow : Window
{

    public FileSelectionWindow()
    {
        InitializeComponent();

        FileSelectionViewModel fileSelectionViewModel = new FileSelectionViewModel();
        this.DataContext = fileSelectionViewModel;
    }

    private async void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListBoxItem item = (ListBoxItem)sender;
        string selectedFilePath = item.Content.ToString();

        var viewModel = (FileSelectionViewModel)DataContext;
        await viewModel.ImportClients(selectedFilePath);
    }
}