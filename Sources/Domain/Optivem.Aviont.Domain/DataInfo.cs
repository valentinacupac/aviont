using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Domain
{
    /// <summary>
    /// Provides meta-information about a DataPath object and includes synchronization data
    /// </summary>
    public class DataInfo
    {
        public DataInfo(string name, string description, DateTime? lastUpdate)
        {
            this.Name = name;
            this.Description = description;
            this.LastUpdate = lastUpdate;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime? LastUpdate { get; private set; }
    }
}
