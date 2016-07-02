using System;
using System.Net;

namespace SnapshotService
{
    public class WebClientEx : WebClient
    {
        public int Timeout { get; set; } = 5000;

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = Timeout;
            }
            return request;
        }
    }
}