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
        /// Returns the name of the data provider
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns collection of table keys which are accessible from the provider
        /// </summary>
        ICollection<string> Tables { get; }

        /// <summary>
        /// Reads data from the external data provider
        /// </summary>
        /// <param name="request">Defines request for which data should be retrieved</param>
        /// <returns>Result data set which was read from the provider</returns>
        DataSet ReadData(string table, DataRequest request);
    }
}
