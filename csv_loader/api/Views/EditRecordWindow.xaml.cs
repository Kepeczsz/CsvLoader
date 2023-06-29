
using Modules.User.Application.ImportingClients;
using Modules.User.Infrastructure.Data;
using System.Linq;
using System.Text;
using System.Windows;

namespace Modules.User.Application.views;

/// <summary>
/// Interaction logic for EditRecordWindow.xaml
/// </summary>
public partial class EditRecordWindow : Window
{
    private ClientDbContext clientDbContext;
    public EditRecordWindow(ClientDbContext clientDbContext)
    {
        this.clientDbContext = clientDbContext;
        InitializeComponent();
    }

    public void Save_Click(object sender, RoutedEventArgs e)
    {

        int id;
        if (!int.TryParse(Id.Text, out id))
        {
            MessageBox.Show("Invalid Id value. Please enter a valid integer.");
            return;
        }
        string name = txtName.Text;
        string surname = txtSurname.Text;
        string email = txtEmail.Text;
        string phoneNumber = txtPhoneNumber.Text;

        var client = clientDbContext.Clients.FirstOrDefault(c => c.Id == id);
        var validator = new GetClientValidator();

        if (client != null)
        {
            client.Name = name;
            client.Surname = surname;
            client.Email = email;
            client.PhoneNumber = phoneNumber;

            var validationResult = validator.Validate(client);

            if (validationResult.IsValid)
            {
                MessageBox.Show("Client changed succesfully");
                clientDbContext.SaveChanges();
            }
            else
            {
                StringBuilder errorList = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    errorList.Append(error.ErrorMessage).Append(" ");
                }
                MessageBox.Show(errorList.ToString());
            }
        }
        this.Close();
    }

    public void Cancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}