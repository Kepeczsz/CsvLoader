using Microsoft.Win32;
using Modules.User.Api;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Modules.User.Application.views;

public partial class FileSelectionWindow : Window
{
    public string SelectedFilePath { get; private set; }
    ClientController clientController;

    public FileSelectionWindow(ClientController clientController)
    {
        this.clientController = clientController;
        InitializeComponent();
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

    private async void ImportClients_Click(object sender, RoutedEventArgs e, string selectedFilePath)
    {
        var importResult = await clientController.ImportClients(selectedFilePath);

        if (importResult != null)
        {
            MessageBox.Show("Clients imported successfully!");
        }
    }

    private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        ListBoxItem item = (ListBoxItem)sender;
        string selectedFilePath = item.Content.ToString();

        ImportClients_Click(sender, e, selectedFilePath);
    }

}