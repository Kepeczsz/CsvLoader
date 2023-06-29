using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application;
using Modules.User.Application.Shared.Services;
using Modules.User.Application.views;
using System;
using System.ComponentModel;
using System.Windows;


namespace Modules.User.Application.views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    IServiceProvider serviceProvider;
    public MainWindow(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void Load_FileSelectionWindow_Click(object sender, RoutedEventArgs e)
    {
        FileSelectionWindow fileSelectionWindow = serviceProvider.GetRequiredService<FileSelectionWindow>();
        fileSelectionWindow.Show();
    }
}