using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFMangament
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            // Tutaj możesz otworzyć swoje główne okno aplikacji
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
