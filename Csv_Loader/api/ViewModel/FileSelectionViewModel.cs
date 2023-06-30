using api;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.projectConfiguration;
using Modules.User.Application.views;
using System.Windows;
using System.Windows.Input;

namespace Modules.User.Application.ViewModel;

public class FileSelectionViewModel
{
    public FileSelectionViewModel()
    {
        OpenEditRecordView = new RelayCommand(EditRecord_Click, CanChangeView);
    }
    public ICommand OpenEditRecordView { get; set; }

    private void EditRecord_Click(object sender)
    {
        EditRecordWindow editRecordWindow = App.serviceProvider.GetRequiredService<EditRecordWindow>();
        editRecordWindow.Show();
    }


    private bool CanChangeView(object sender)
    {
        return true;
    }
}