using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents a header for a data set
    /// </summary>
    public class DataHeader
    {
        public DataHeader(params DataField[] fields)
        {
            this.Fields = fields;
        }

        public DataField[] Fields { get; private set; }
    }
}