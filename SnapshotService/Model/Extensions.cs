using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace SnapshotService
{
    public static class Extensions
    {
        public static bool IsNotEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static void SaveEvent(this string message, EventId eventId, EventLogEntryType eventLogEntryType = EventLogEntryType.Information)
        {
            EventLog.WriteEntry(Properties.Resources.EventSourceName, message, eventLogEntryType, (int)eventId);
            Console.WriteLine("[{0}] -> {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), message);
        }

        public static void LogInfo(this string message, EventId eventId, params object[] args)
        {
            SaveEvent(string.Format(message, args), eventId);
        }

        public static void LogException(this Exception exception, EventId eventId)
        {
            SaveEvent(exception.ToString(), eventId, EventLogEntryType.Error);
        }

        public static T Deserialize<T>(this string value)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return serializer.Deserialize<T>(value);
        }

        public static byte[] GetBytes<T>(this T data, int maxJsonLength = 10240000, int recursionLimit = 100)
        {
            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer
            {
                MaxJsonLength = maxJsonLength,
                RecursionLimit = recursionLimit,
            };
            return Encoding.UTF8.GetBytes(serializer.Serialize(data));
        }

        public static string GetRemoteAddress(this OperationContext context, string addressFormat = "{0}:{1}")
        {
            var messageProperties = context.IncomingMessageProperties;
            var endpointProperty = (RemoteEndpointMessageProperty)messageProperties[RemoteEndpointMessageProperty.Name];
            var address = !endpointProperty.Address.Equals("::1") ? endpointProperty.Address : "localhost";
            return string.Format(addressFormat, address, endpointProperty.Port);
        }

        public static Message CreateMessage(this byte[] message, WebSocketMessageType messageType = WebSocketMessageType.Text)
        {
            var result = ByteStreamMessage.CreateMessage(new ArraySegment<byte>(message));
            result.Properties["WebSocketMessageProperty"] = new WebSocketMessageProperty
            {
                MessageType = messageType
            };
            return result;
        }

        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
