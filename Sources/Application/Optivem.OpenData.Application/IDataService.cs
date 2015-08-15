using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Application
{
    public interface IDataService
    {
        ICollection<string> GetProviderKeys();
    }
}
