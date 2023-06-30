using api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using Modules.User.Application.Controllers;
using Modules.User.Application.ImportingClients;
using Modules.User.Application.projectConfiguration;
using Modules.User.Application.views;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Modules.User.Application.ViewModel;

public class FileSelectionViewModel
{
    public ObservableCollection<string> FileNames { get; set; }
    public ObservableCollection<Client> listOfClients { get; set; }

    ClientController clientController;

    public FileSelectionViewModel()
    {
        this.clientController = App.serviceProvider.GetService<ClientController>();

        FileNames = new ObservableCollection<string>();
        listOfClients = new ObservableCollection<Client>();

        OpenEditRecordViewCommand = new RelayCommand(ChangeViewToEditRecord, CanExecute);
        SelectFileCommand = new RelayCommand(SelectFile, CanExecute);
    }

    public ICommand OpenEditRecordViewCommand { get; set; }
    public ICommand SelectFileCommand { get; set; }

    private void ChangeViewToEditRecord(object sender)
    {
        EditRecordWindow editRecordWindow = App.serviceProvider.GetRequiredService<EditRecordWindow>();
        editRecordWindow.Show();
    }

    private void SelectFile(object sender)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
        if (openFileDialog.ShowDialog() == true)
        {
            foreach (string filename in openFileDialog.FileNames)
                FileNames.Add(filename);
        }
    }

    public async Task ImportClients(string selectedFilePath)
    {
        var importResult = await clientController.ImportClients(selectedFilePath);

        if (importResult != null)
        {
            MessageBox.Show("Clients imported successfully!");
        }

        if (importResult != null)
        {
            foreach (var client in importResult.listOfClients)
            {
                listOfClients.Add(client);
            }
        }
    }


    private bool CanExecute(object sender)
    {
        return true;
    }


}