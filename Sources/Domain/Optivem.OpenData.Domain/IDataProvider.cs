using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.OpenData.Domain
{
    /// <summary>
    /// Represents an external provider of data
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Reads data from the external data provider
        /// </summary>
        /// <param name="request">Defines request for which data should be retrieved</param>
        /// <returns>Result data set which was read from the provider</returns>
        DataSet ReadData(DataRequest request);
    }
}
