using Microsoft.Extensions.DependencyInjection;
using Modules.User.Api;
using Modules.User.Application.shared.services;
using Modules.User.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace api
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientController clientController;


        public MainWindow(ClientController clientController)
        {
            this.clientController = clientController;
            InitializeComponent();
            clientController.ImportClients("C:\\Users\\sm49416\\Desktop\\projekt\\csv_loader\\api\\employes.csv");
        }
    }
}
