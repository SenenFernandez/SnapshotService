using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnapshotService
{
    public class SnapshotManager : IDisposable
    {
        private CancellationTokenSource tokenSource;

        public bool IsStarted { get; private set; }
        public IEnumerable<Camera> Cameras { get; set; }
        public event EventHandler<SnapshotReceivedEventArgs> SnapshotReceived;

        public void Start()
        {
            if (!IsStarted)
            {
                Cameras = ConfigurationManager.AppSettings["cameras"].Deserialize<IEnumerable<Camera>>();
                tokenSource = new CancellationTokenSource();
                IsStarted = true;
                if (Cameras != null)
                {
                    foreach (var camera in Cameras.Where(c => !c.IsDisabled))
                    {
                        var task = Task.Factory.StartNew(async () =>
                        {
                            do
                            {
                                TakeSnapshot(camera);
                                await Task.Delay(TimeSpan.FromSeconds(camera.Period), tokenSource.Token);
                            } while (IsStarted);
                        }, tokenSource.Token);
                    }
                }
            }
        }

        public void TakeSnapshots()
        {
            if (Cameras != null)
            {
                foreach (var camera in Cameras.Where(c => !c.IsDisabled))
                {
                    TakeSnapshot(camera);
                }
            }
        }

        private void TakeSnapshot(Camera camera)
        {
            try
            {
                var now = DateTime.Now;
                string path = string.Format(@"{0}\{1}", camera.Path, now.ToString("yyyyMMdd"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = string.Format(@"{0}\{1}.jpg", path, now.ToString("yyyyMMdd_HHmmss"));
                using (var wc = new WebClientEx())
                {
                    if (camera.Credentials.IsNotEmpty())
                    {
                        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(camera.Credentials));
                        wc.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
                    }
                    wc.DownloadFile(camera.Url, fileName);
                    SnapshotReceived?.Invoke(camera, new SnapshotReceivedEventArgs(camera.Name, fileName, now));
                }
            }
            catch (Exception ex)
            {
                ex.LogException(EventId.ErrorTakingSnapshot);
            }
        }

        #region IDisposable
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    IsStarted = false;
                    if (tokenSource != null)
                    {
                        tokenSource.Cancel();
                        tokenSource.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
