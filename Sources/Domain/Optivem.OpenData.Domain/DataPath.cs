using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents a symbolic path to data (for example, holding information about the data provider and the data source)
    /// </summary>
    public class DataPath
    {
        public DataPath(Dictionary<string, string> path)
        {
            this.Path = path;
        }

        public Dictionary<string, string> Path { get; private set; }
    }
}
