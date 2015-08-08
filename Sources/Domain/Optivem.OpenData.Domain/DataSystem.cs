using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents the data system which consists of external data providers, internal storage and a synchronizer between these sources
    /// </summary>
    public class DataSystem
    {
        public DataSystem(IDataStorage storage, List<IDataProvider> providers)
        {
            this.Storage = storage;
            this.Providers = providers;
        }

        public IDataStorage Storage { get; private set; }

        public List<IDataProvider> Providers { get; private set; }
    }
}
