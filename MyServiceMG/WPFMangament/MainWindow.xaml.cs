using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
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
using System.Diagnostics;
using Uslugi;
using Zad2;
using System.Threading;

namespace WPFMangament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceController serviceController;
        ServiceController[] scServices;
        public string name = "MojaUsluga2";
        

        public MainWindow()
        {
            InitializeComponent();
            scServices = ServiceController.GetServices();
            foreach (ServiceController scTemp in scServices)
            {
                if (scTemp.ServiceName == name)
                {
                    serviceController = new ServiceController(name);
                }
            }
            UpdateUI();
            SubscribeToEventLog();
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            //serviceController = new ServiceController("MojaUsluga2");
            try
            {

                if (serviceController.Status == ServiceControllerStatus.Stopped)
                {
                    serviceController = new ServiceController(name);
                    serviceController.Start();
                    //serviceController.Refresh();
                    //serviceController.WaitForStatus(ServiceControllerStatus.Running);
                    UpdateUI();
                    while (serviceController.Status == ServiceControllerStatus.Stopped || serviceController.Status == ServiceControllerStatus.StartPending)
                    {
                        Thread.Sleep(1000);
                        serviceController.Refresh();
                        UpdateUI();
                    }
                }
                
                         
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Blad uruchomienia uslugi: {ex.Message}");
            }
        }

        private void bStop_Click(object sender, RoutedEventArgs e)
        {
            serviceController = new ServiceController(name);
            try
            {
                if (serviceController.Status == ServiceControllerStatus.Running || serviceController.Status == ServiceControllerStatus.StartPending)
                {
                    serviceController = new ServiceController(name);
                    serviceController.Stop();
                    //serviceController.WaitForStatus(ServiceControllerStatus.Running);
                    UpdateUI();
                    while (serviceController.Status == ServiceControllerStatus.Running || serviceController.Status == ServiceControllerStatus.StopPending)
                    {
                        Thread.Sleep(1000);
                        serviceController.Refresh();
                        UpdateUI();
                    }
                }
                //serviceController.Stop();
                //serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                //UpdateUI();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Blad zatrzymania uslugi: {ex.Message}");
            }
        }
        private void UpdateUI()
        {
            //bool isserviceRunning = serviceController.Status == ServiceControllerStatus.Running;
            //bStart.IsEnabled = !isserviceRunning;
            //bStop.IsEnabled = isserviceRunning;
            if (serviceController.Status == ServiceControllerStatus.Stopped )
            {
                bStart.IsEnabled = true;
                bStop.IsEnabled = false;
            }
            else
            {
                bStart.IsEnabled = false;
                bStop.IsEnabled = true;
            }
            statusLabel.Content = $"Status {serviceController.ServiceName}: {serviceController.Status}";
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            eventLogTextBox.Clear();
            EventLog eventLog = new EventLog("MojaUsluga2Log");

            foreach (EventLogEntry entry in eventLog.Entries) {
                eventLogTextBox.AppendText($"{entry.TimeGenerated}: {entry.Message}\n");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            eventLogTextBox.Clear();
        }

        private void SubscribeToEventLog() {
            EventLog eventLog = new EventLog("MojaUsluga2Log");
            eventLog.EntryWritten += EventLog_EntryWritten;
            eventLog.EnableRaisingEvents = false;
        }

        private void EventLog_EntryWritten(object sender, EntryWrittenEventArgs e) {
            // Aktualizuj log zdarzeń w czasie rzeczywistym
            Dispatcher.Invoke(() => eventLogTextBox.AppendText($"{DateTime.Now}: {e.Entry.Message}\n"));
        }

        private void eventLogTextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void eventLogTextBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e) {

        }
    }
}
