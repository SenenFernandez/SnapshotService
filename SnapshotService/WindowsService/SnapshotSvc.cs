using System.Diagnostics;
using System.ServiceModel;
using System.ServiceProcess;

namespace SnapshotService
{
    /// <summary>
    /// Install:    C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe SnapshotService.exe
    /// Uninstall:  C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe SnapshotService.exe /u
    /// </summary>
    partial class SnapshotSvc : ServiceBase
    {
        private ServiceHost host;

        public SnapshotSvc()
        {
            if (!EventLog.SourceExists(Properties.Resources.EventSourceName))
            {
                EventLog.CreateEventSource(Properties.Resources.EventSourceName, EventLog.Log);
            }
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DoStart();
        }

        protected override void OnStop()
        {
            DoStop();
        }

        public void DoStart()
        {
            Properties.Resources.StartingWindowsService.LogInfo(EventId.StartingWindowsService);
            if (host != null)
            {
                host.Close();
            }
            host = new ServiceHost(typeof(SnapshotService));
            //netsh http add urlacl url=http://+:8023/SnapshotService user=SenenFernandezDomain\Senen
            host.Open();
        }

        public void DoStop()
        {
            Properties.Resources.StopingWindowsService.LogInfo(EventId.StopingWindowsService);
            if (host != null)
            {
                host.Close();
                host = null;
                //netsh http delete urlacl url=http://+:8023/SnapshotService
            }
        }
    }
}
