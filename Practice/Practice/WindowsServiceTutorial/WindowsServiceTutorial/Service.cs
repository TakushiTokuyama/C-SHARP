using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceTutorial
{
    public partial class Service : ServiceBase
    {
        public enum ServiceState
        {
            SERVICE_STOPPED = 0x00000001,
            SERVICE_START_PENDING = 0x00000002,
            SERVICE_STOP_PENDING = 0x00000003,
            SERVICE_RUNNING = 0x00000004,
            SERVICE_CONTINUE_PENDING = 0x00000005,
            SERVICE_PAUSE_PENDING = 0x00000006,
            SERVICE_PAUSED = 0x00000007,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ServiceStatus
        {
            public int dwServiceType;
            public ServiceState dwCurrentState;
            public int dwControlsAccepted;
            public int dwWin32ExitCode;
            public int dwServiceSpecificExitCode;
            public int dwCheckPoint;
            public int dwWaitHint;
        };

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

        private int eventId = 1;

        private EventLogWatcher eventLogWatcher = new EventLogWatcher("MyNewLog");
        public Service()
        {
            InitializeComponent();
            eventLog = new EventLog();
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog.Source = "MySource";
            eventLog.Log = "MyNewLog";

            eventLogWatcher.EventRecordWritten += new EventHandler<EventRecordWrittenEventArgs>(writeEvent);

            // イベントログ監視開始
            eventLogWatcher.Enabled = true;

            Timer timer = new Timer();
            timer.Interval = 60000;
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

        }

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            eventLog.WriteEntry("System", EventLogEntryType.Information, eventId++);
        }

        /// <summary>
        /// イベントログ発生時にログ出力
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="arg"></param>
        public void writeEvent(Object obj, EventRecordWrittenEventArgs arg)
        {
            if (arg.EventRecord.Id > 0)
            {
                eventLog.WriteEntry("Eventが発生しました。", EventLogEntryType.Information);
            }
        }

        /// <summary>
        /// 開始
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("On Start", EventLogEntryType.Information);

            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOP_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        /// <summary>
        /// 停止
        /// </summary>
        protected override void OnStop()
        {
            eventLog.WriteEntry("On Stop", EventLogEntryType.Information);
        }

        protected override void OnContinue()
        {
            eventLog.WriteEntry("OnContinue");
        }

        protected override void OnPause()
        {
            eventLog.WriteEntry("OnPause");
            base.OnPause();
        }

        protected override void OnShutdown()
        {
            eventLog.WriteEntry("OnShutdown");
            base.OnShutdown();
        }

        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            eventLog.WriteEntry("powerStatus");
            return base.OnPowerEvent(powerStatus);
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
