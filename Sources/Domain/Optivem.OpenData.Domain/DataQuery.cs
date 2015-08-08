using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents a data query
    /// </summary>
    public class DataQuery
    {
        public DataQuery(Dictionary<string, object> parameters)
        {
            this.Parameters = parameters;
        }

        public Dictionary<string, object> Parameters { get; private set; }
    }
}
