using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace Uslugi
{
    public class UslugaNr1 : ServiceBase
    {
        public const string NazwaUslugi = "MojSerwis";
        public UslugaNr1()
        {
            this.ServiceName = NazwaUslugi; 

        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }
        protected void OnStop(string[] args) { }

    }
}
