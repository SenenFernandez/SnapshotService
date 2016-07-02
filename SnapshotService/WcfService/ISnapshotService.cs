using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace SnapshotService
{
    [ServiceContract(CallbackContract = typeof(ISnapshotServiceCallback))]
    interface ISnapshotService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        [WebInvoke(Method = "POST"
            , BodyStyle = WebMessageBodyStyle.Wrapped
            , RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , UriTemplate = "*")]
        Task Send(Message message);
    }
}
