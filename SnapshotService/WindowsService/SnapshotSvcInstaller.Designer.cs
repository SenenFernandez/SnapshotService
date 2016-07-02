namespace SnapshotService
{
    partial class SnapshotSvcInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.Description = "Security Cameras Service";
            this.serviceInstaller.DisplayName = "Security Cameras Service";
            this.serviceInstaller.ServiceName = "SnapshotSvc";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.OnAfterInstall);
            // 
            // processInstaller
            // 
            this.processInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.processInstaller.Password = null;
            this.processInstaller.Username = null;
            // 
            // SnapshotSvcInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceInstaller,
            this.processInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceInstaller serviceInstaller;
        private System.ServiceProcess.ServiceProcessInstaller processInstaller;
    }
}