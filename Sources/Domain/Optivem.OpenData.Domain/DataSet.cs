using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents an in-memory representation of a set of data
    /// </summary>
    public class DataSet
    {
        public DataSet(DataHeader header, List<DataRecord> records)
        {
            this.Header = header;
            this.Records = records;
        }

        public DataHeader Header { get; private set; }

        public List<DataRecord> Records { get; private set; }
    }
}
