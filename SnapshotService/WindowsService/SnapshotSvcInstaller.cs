using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace SnapshotService
{
    [RunInstaller(true)]
    public partial class SnapshotSvcInstaller : Installer
    {
        public SnapshotSvcInstaller()
        {
            InitializeComponent();
        }

        private void OnAfterInstall(object sender, InstallEventArgs e)
        {
            var si = sender as ServiceInstaller;
            if (si != null)
            {
                new ServiceController(si.ServiceName).Start();
            }
        }
    }
}
