using System.Runtime.Serialization;

namespace SnapshotService
{
    [DataContract()]
    public class SnapshotClient : IExtensibleDataObject
    {
        [DataMember(Name = "UserName", IsRequired = true)]
        public string UserName { get; set; }
        [DataMember(Name = "Message", IsRequired = true)]
        public string Message { get; set; }
        internal ISnapshotServiceCallback Callback { get; set; }
        public ExtensionDataObject ExtensionData { get; set; }
    }
}