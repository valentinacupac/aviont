using Optivem.Aviont.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Aviont.Application
{
    public class DataService : IDataService
    {
        private Dictionary<string, IDataProvider> providers;

        public DataService(DataSystem system)
        {
            this.System = system;
            this.providers = system.Providers.ToDictionary(e => e.Name, e => e);
        }

        public DataSystem System { get; private set; }

        public ICollection<string> GetProviderKeys()
        {
            return providers.Keys;
        }

        public bool HasProvider(string provider)
        {
            return providers.ContainsKey(provider);
        }

        public ICollection<string> GetTableKeys(string provider)
        {
            if(!providers.ContainsKey(provider))
            {
                throw new ArgumentOutOfRangeException("Provider does not exist: " + provider);
            }

            return providers[provider].Tables;
        }

        public bool HasTable(string provider, string table)
        {
            if(!providers.ContainsKey(provider))
            {
                return false;
            }

            return providers[provider].Tables.Contains(table);
        }

        public DataSet ReadDataSet(string provider, string table, DataRequest request)
        {
            IDataProvider providerObj = providers[provider];
            return providerObj.ReadData(table, request);
        }
    }
}
