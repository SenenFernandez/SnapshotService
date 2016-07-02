using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace SnapshotService
{
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = true, IncludeExceptionDetailInFaults = true)]
    //[CallbackBehavior(AutomaticSessionShutdown = true, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = true, IncludeExceptionDetailInFaults = true)]
    public class SnapshotService : ISnapshotService, IDisposable
    {
        private static ConcurrentDictionary<string, SnapshotClient> clients = new ConcurrentDictionary<string, SnapshotClient>();
        private SnapshotManager manager;

        public SnapshotService()
        {
            manager = new SnapshotManager();
            manager.SnapshotReceived += OnSnapshotReceived;
            manager.Start();
        }

        public async Task Send(Message message)
        {
            if (message.IsEmpty)
            {
                return;
            }

            var context = OperationContext.Current;
            string clientAddress = context.GetRemoteAddress();

            SnapshotClient client;
            var body = message.GetBody<byte[]>();
            using (var stream = new MemoryStream(body))
            {
                var ser = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(SnapshotClient));
                client = (SnapshotClient)ser.ReadObject(stream);
            }

            SnapshotClient newclient;
            if (!clients.TryGetValue(clientAddress, out newclient))
            {
                client.Callback = context.GetCallbackChannel<ISnapshotServiceCallback>();
                clients.TryAdd(clientAddress, client);
                Properties.Resources.NewClientMessage.LogInfo(EventId.NewClientMessage, clientAddress, client.Message);
                var list = clients.Where(c => ((IChannel)c.Value.Callback).State != CommunicationState.Opened);
                foreach (var c in list)
                {
                    SnapshotClient remove;
                    clients.TryRemove(c.Key, out remove);
                }
                manager.TakeSnapshots();
            }
            else
            {
                Properties.Resources.ClientMessage.LogInfo(EventId.ClientMessage, clientAddress, client.Message);
            }
            await Task.Delay(0);
        }

        private void OnSnapshotReceived(object sender, SnapshotReceivedEventArgs e)
        {
            SendToAllClients(e);
        }

        private void SendToAllClients(SnapshotReceivedEventArgs e)
        {
            var list = clients.Values.Where(c => ((IChannel)c.Callback).State == CommunicationState.Opened).ToList();
            if (list.Count > 0)
            {
                var message = e.GetBytes();
                foreach (var client in list)
                {
                    client.Callback.Receive(message.CreateMessage());
                }
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
                    manager.Dispose();
                    manager = null;
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