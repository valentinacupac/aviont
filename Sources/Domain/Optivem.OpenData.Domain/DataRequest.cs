using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Specifies a request to extract data from some source according to some criteria (it is composed of a DataPath and a DataQuery object)
    /// </summary>
    public class DataRequest
    {
        public DataRequest(DataPath path, DataQuery query)
        {
            this.Path = path;
            this.Query = query;
        }

        public DataPath Path { get; private set; }

        public DataQuery Query { get; private set; }
    }
}
