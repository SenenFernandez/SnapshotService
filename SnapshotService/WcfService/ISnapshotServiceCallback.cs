using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace SnapshotService
{
    [ServiceContract]
    interface ISnapshotServiceCallback
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        Task Receive(Message message);
    }
}