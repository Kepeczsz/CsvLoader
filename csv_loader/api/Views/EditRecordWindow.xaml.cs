using api;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.Controllers;
using Modules.User.Application.ImportingClients;
using Modules.User.Application.ViewModel;
using Modules.User.Domain;
using Modules.User.Infrastructure.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace Modules.User.Application.views;

public partial class EditRecordWindow : Window
{
    ClientController clientController;
    public EditRecordWindow()
    {
        InitializeComponent();
        EditRecordModelView fileSelectionViewModel = new EditRecordModelView();
        this.DataContext = fileSelectionViewModel;
    }



    public void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}