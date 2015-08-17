using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Infrastructure.Readers
{
    public static class TextReaderFactory
    {
        public static TextReader FromString(string content)
        {
            return new StringReader(content);
        }

        public static TextReader FromWeb(string address)
        {
            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString(address);
                return new StringReader(content);

                // TODO: Also consider possibility of saving to a file? (compare efficiency)
            }
        }

        public static TextReader FromDisk(string path)
        {
            return new StreamReader(path);
        }
    }
}
