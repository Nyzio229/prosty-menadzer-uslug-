using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Zad2
{
    public partial class Service1 : ServiceBase
    {
        private EventLog eventLog;
        private System.Timers.Timer timer;

        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "MojaUsluga2";
            this.CanStop = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            //InitializeEventLog();
            //InitializeTimer();
            //LogEvent("ServiceStarted");
            InitializeEventLog();
            LogEvent("Service started.");

            // Inicjalizacja i konfiguracja timera
            timer = new System.Timers.Timer();
            timer.Interval = 30000; // 30 sekund
            timer.Elapsed += TimerElapsed;
            timer.Start();
        }

        protected override void OnStop()
        {
            //timer.Stop();
            //timer.Dispose();
            //LogEvent("ServiceStopped");

            LogEvent("Service stopped.");
            eventLog.Dispose();
            timer.Stop();
            timer.Dispose();
        }
        private void InitializeEventLog()
        {
            //if (!EventLog.SourceExists("MojaUsluga2Source"))
            //{
            //    EventLog.CreateEventSource("MojaUsluga2Source", "MojaUsluga2");
            //}
            //eventLog = new EventLog();
            //eventLog.Source = "MojaUsluga2Source";
            //eventLog.Log = "MojaUsluga2Log";

            // Utwórz lub otwórz dziennik zdarzeń
            if (!EventLog.SourceExists("MojaUsluga2Source")) {
                EventLog.CreateEventSource("MojaUsluga2Source", "MojaUsluga2Log");
            }

            eventLog = new EventLog();
            eventLog.Source = "MojaUsluga2Source";
            eventLog.Log = "MojaUsluga2Log";
        }
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 30 * 1000;
            timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
            timer.Enabled = true;
            timer.Start();

        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e) 
        {
            LogEvent("Serive is still running...");
        }
        private void LogEvent(string message) 
        {
            eventLog.WriteEntry(message, EventLogEntryType.Information);
        }
    }
}
