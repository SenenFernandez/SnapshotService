using System;

namespace SnapshotService
{
    public class SnapshotReceivedEventArgs : EventArgs
    {
        public string Camera { get; private set; }
        public string Image { get; private set; }
        public DateTime Timestamp { get; private set; }

        public SnapshotReceivedEventArgs(string camera, string image, DateTime? timestamp = null)
        {
            Camera = camera;
            Timestamp = timestamp ?? DateTime.Now;
            Image = System.IO.File.ReadAllBytes(image).ToBase64String();
        }
    }
}