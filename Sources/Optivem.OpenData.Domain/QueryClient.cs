using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    public class QueryClient : IDisposable
    {
        private WebClient client;

        public QueryClient()
        {
            this.client = new WebClient();
        }

        public void DownloadFile(string address, string filePath)
        {
            client.DownloadFile(address, filePath);
        }

        public string DownloadString(string address)
        {
            return client.DownloadString(address);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
