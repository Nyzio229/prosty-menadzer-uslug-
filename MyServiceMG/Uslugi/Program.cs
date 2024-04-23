using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.ComponentModel;
using System.Configuration.Install;

namespace Uslugi
{
    [RunInstaller(true)]
    public class Program : Installer
    {
        public Program() 
        {
            ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            //serviceProcessInstaller.Account = ServiceAccount.LocalService;
            //serviceProcessInstaller.Account = ServiceAccount.User;
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.ServiceName = UslugaNr1.NazwaUslugi;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.DisplayName = "Mój Pierwszy Serwis";
            this.Installers.Add(serviceProcessInstaller);
            this.Installers.Add(serviceInstaller);
        }
     
    }
}
