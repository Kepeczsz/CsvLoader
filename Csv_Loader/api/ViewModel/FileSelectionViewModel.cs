using api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using Modules.User.Application.projectConfiguration;
using Modules.User.Application.views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Modules.User.Application.ViewModel;

public class FileSelectionViewModel
{
    public ObservableCollection<string> FileNames { get; set; }

    public FileSelectionViewModel()
    {
        FileNames = new ObservableCollection<string>();

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

    private bool CanExecute(object sender)
    {
        return true;
    }
}