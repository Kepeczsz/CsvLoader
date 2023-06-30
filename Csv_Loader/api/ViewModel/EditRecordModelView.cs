using api;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.Controllers;
using Modules.User.Application.projectConfiguration;
using Modules.User.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Modules.User.Application.ViewModel;

public class EditRecordModelView
{
    public ICommand SaveCommand { get; set; }
    ClientController clientController;

    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public EditRecordModelView()
    {
        this.clientController = App.serviceProvider.GetService<ClientController>();
        SaveCommand = new RelayCommand(Save, CanExecute);
    }

    public async void Save(object sender)
    {

        int id;
        if (!int.TryParse(Id, out id))
        {
            MessageBox.Show("Invalid Id value. Please enter a valid integer.");
            return;
        }
        string name = Name;
        string surname = Surname;
        string email = Email;
        string phoneNumber = PhoneNumber;

        clientController.ChangeClientData(new Client(id, name, surname, email, phoneNumber));
    }

    private bool CanExecute(object sender)
    {
        return true;
    }
}