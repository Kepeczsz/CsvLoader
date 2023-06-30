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
    public string SelectedFilePath { get; private set; }
    IServiceProvider serviceProvider;
    ClientController clientController;

    public FileSelectionWindow(ClientController clientController, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        this.clientController = clientController;
        InitializeComponent();

        FileSelectionViewModel mainViewModel = new FileSelectionViewModel();
        this.DataContext = mainViewModel;
    }

    private void SelectFile_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
        if (openFileDialog.ShowDialog() == true)
        {
            foreach (string filename in openFileDialog.FileNames)
                lbFiles.Items.Add(filename);
        }
    }

    private async Task<ClientList> ImportClients_Click(object sender, RoutedEventArgs e, string selectedFilePath)
    {
        var importResult = await clientController.ImportClients(selectedFilePath);

        if (importResult != null)
        {
            MessageBox.Show("Clients imported successfully!");
        }

        return importResult;
    }

    private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListBoxItem item = (ListBoxItem)sender;
        string selectedFilePath = item.Content.ToString();

        var clientList = ImportClients_Click(sender, e, selectedFilePath);

        if (clientList != null)
        {
            importedClientsListView.ItemsSource = clientList.Result.listOfClients;
        }
    }

}