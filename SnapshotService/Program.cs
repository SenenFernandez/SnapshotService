using System;
using System.ServiceProcess;

namespace SnapshotService
{
    class Program
    {
        static void Main(string[] args)
        {
            var windowsService = new SnapshotSvc();
            if (!Environment.UserInteractive)
            {
                var servicesToRun = new ServiceBase[] { windowsService };
                ServiceBase.Run(servicesToRun);
            }
            else
            {
                windowsService.DoStart();
                Properties.Resources.ConsoleMode.LogInfo(EventId.ConsoleMode);
                Console.ReadKey();
                windowsService.DoStop();
            }
        }
    }
}