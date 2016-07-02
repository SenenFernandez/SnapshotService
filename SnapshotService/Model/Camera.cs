namespace SnapshotService
{
    public class Camera
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Url { get; set; }
        public string Credentials { get; set; }
        public string Path { get; set; }
        public int Period { get; set; } = 60;
        public bool IsDisabled { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}